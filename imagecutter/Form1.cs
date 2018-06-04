using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using ImageMagick;
using System.Threading;

namespace imagecutter
{

    public partial class mainForm : Form
    {
        string sourcePath = "";
        string outputPath = "";
        Thread thr;
        String logFileName = "imagecutter.log";
        String exLogFileName = "imagecutter_exception.log"; 
        

        Stopwatch sw;

        public void log(String lines)
        {
            StreamWriter logFile = new StreamWriter(logFileName, true);
            logFile.WriteLine("[" + (int)sw.Elapsed.TotalMilliseconds + "] " + lines);

            logFile.Close();

        }

        public void logException(Exception e)
        {
            StreamWriter logFile = new StreamWriter(exLogFileName, true);
            logFile.WriteLine("[" + (int)sw.Elapsed.TotalMilliseconds + "] " + e.ToString());

            logFile.Close();
        }

        public mainForm()
        {
            sw = Stopwatch.StartNew();
            log("====== START[" + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss") + "] =====");
            InitializeComponent();
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void bBrowseSource_Click(object sender, EventArgs e)
        {
            if (dlgOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbSourcePath.Text = dlgOpenFile.FileName;
            }
        }

        private void bOutputBrowse_Click(object sender, EventArgs e)
        {
            if (dlgBrowseFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbOutputPath.Text = dlgBrowseFolder.SelectedPath;
            }
        }

        private void tbSourcePath_TextChanged(object sender, EventArgs e)
        {
            bStart.Enabled = File.Exists(tbSourcePath.Text);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            tbOutputPath.Text = Directory.GetCurrentDirectory();
            log("tbOutputPath.Text = " + tbOutputPath.Text);
        }
        
        void cutMapAsync(MagickImage img, string targetPath, int size=512)
        {
            log("start cutMapAsync with img=MagicImageObject(" + img.Width + "x" + img.Height + "), targetPath=" + targetPath + ", size=" + size);
            int width = img.Width;
            int height = img.Height;
            int x = 0;
            int y = 0;
            int w = 0;
            int h = 0;
            pbSub.Invoke(new Action(() => pbSub.Maximum = (int)Math.Ceiling((double)width/size) * (int)Math.Ceiling((double)height / size)));
            log("subProgressBar maximum value set to "+ ((int)Math.Ceiling((double)width / size) * (int)Math.Ceiling((double)height / size)));
            pbSub.Invoke(new Action(() => pbSub.Value = 0));

            while (x*size < width){
                while (y*size < height)
                {
                    log("cropLoop "+x+"x"+y);
                    int X = x;
                    int Y = y;
                    string baseName = String.Format("/map_{0}_{1}", X, Y);
                    log("clone");
                    MagickImage croppedImage = (MagickImage)img.Clone();
                    log("crop");
                    croppedImage.Crop(size * X, size * Y, size, size);
                    if (croppedImage.Width < size || croppedImage.Height < size)
                    {
                        log("extent");
                        croppedImage.Extent(size, size, Color.Black);
                    }
                    MemoryStream bstream = new MemoryStream();
                    log("write cropped image to string");
                    croppedImage.Write(bstream);
                    croppedImage.Dispose();
                    log("convert stream to byte array");
                    Byte[] f = bstream.ToArray();
                    log("fix header");
                    f[21] = 0x0;
                    f[22] = 0x2;
                    f[32] = 0x0;
                    f[33] = 0x0;
                    f[34] = 0x0;
                    f[35] = 0x0;
                    f[36] = 0x0;
                    f[37] = 0x0;
                    f[38] = 0x0;
                    f[39] = 0x0;
                    f[40] = 0x0;
                    f[41] = 0x0;
                    f[42] = 0x0;
                    log("save byte array as final image");
                    File.WriteAllBytes(targetPath + baseName + ".dds", f);

                    if (pbSub.Value < pbSub.Maximum) pbSub.Invoke(new Action(() => pbSub.Value++));
                    lSubStatus.Invoke(new Action(() => lSubStatus.Text = String.Format("Croping [{0}/{1}]", pbSub.Value, pbSub.Maximum)));
                    y += 1;
                }
                y = 0;
                x += 1;
            }
        }

        void mainLoop()
        {
            log("mainloop starts");
            try
            {
                log("init magick image object from source");
                MagickImage img = new MagickImage(sourcePath);
                img.Format = MagickFormat.Dds;
                img.Settings.Compression = Compression.DXT1;
                //img.CompressionMethod = CompressionMethod.DXT1;
                log("set main progress bar maximum value to " + ((int)nudIterations.Value - 1));
                pbMain.Invoke(new Action(() => pbMain.Maximum = (int)nudIterations.Value-1));
                pbMain.Value = 0;
                for (int imgNum = (int)nudIterations.Value-1; imgNum >= 0; imgNum--)
                {
                    log("start mainloop cutting/resizing for with imgNum " + ((int)nudIterations.Value - 1));
                    lStatus.Invoke(new Action(() => lStatus.Text = String.Format("Cutting [{0}/{1}]", pbMain.Value, pbMain.Maximum)));
                    if (!Directory.Exists(outputPath + "/" + imgNum.ToString()))
                    {
                        log("because directory "+ outputPath + "/" + imgNum.ToString() + " is not exists:");
                        log("create directory " + outputPath + "/" + imgNum.ToString());
                        Directory.CreateDirectory(outputPath + "/" + imgNum.ToString());
                    }
                    cutMapAsync(img, outputPath + "/" + imgNum.ToString(), (int)nudChunkSize.Value);
                    lStatus.Invoke(new Action(() => lStatus.Text = String.Format("Resizing [{0}/{1}]", pbMain.Value, pbMain.Maximum)));
                    log("resize img to " + img.Width / 2 + "x"+ img.Height / 2);
                    img.Resize(img.Width / 2, img.Height / 2);

                    if (pbMain.Value < pbMain.Maximum) pbMain.Invoke(new Action(() => pbMain.Value++));
                }
                lStatus.Invoke(new Action(() => lStatus.Text = "Finished"));
                lStatus.Invoke(new Action(() => lSubStatus.Text = ""));
                pbMain.Invoke(new Action(() => pbMain.Value = 0));
                pbSub.Invoke(new Action(() => pbSub.Value = 0));
                bStart.Invoke(new Action(() => bStart.Text = "Start"));
                log("enable input");
                tbOutputPath.Invoke(new Action(() => tbOutputPath.Enabled = true));
                tbSourcePath.Invoke(new Action(() => tbSourcePath.Enabled = true));
                bBrowseSource.Invoke(new Action(() => bBrowseSource.Enabled = true));
                bOutputBrowse.Invoke(new Action(() => bOutputBrowse.Enabled = true));
                nudIterations.Invoke(new Action(() => nudIterations.Enabled = true));
                nudChunkSize.Invoke(new Action(() => nudChunkSize.Enabled = true));
            } catch (MagickException e)
            {
                logException(e);
                lStatus.Invoke(new Action(() => lStatus.Text = "Error: "+e.Message));
                lStatus.Invoke(new Action(() => lSubStatus.Text = ""));
                pbMain.Invoke(new Action(() => pbMain.Value = 0));
                pbSub.Invoke(new Action(() => pbSub.Value = 0));
                bStart.Invoke(new Action(() => bStart.Text = "Start"));
                log("enable input");
                tbOutputPath.Invoke(new Action(() => tbOutputPath.Enabled = true));
                tbSourcePath.Invoke(new Action(() => tbSourcePath.Enabled = true));
                bBrowseSource.Invoke(new Action(() => bBrowseSource.Enabled = true));
                bOutputBrowse.Invoke(new Action(() => bOutputBrowse.Enabled = true));
                nudIterations.Invoke(new Action(() => nudIterations.Enabled = true));
                nudChunkSize.Invoke(new Action(() => nudChunkSize.Enabled = true));
            } catch (Exception e)
            {
                logException(e);
            }
            log("mainloop ends");
        }
        
        private void bStart_Click(object sender, EventArgs e)
        {
            try
            {
                log("bStart clicked");
                if (bStart.Text == "Stop")
                {
                    log("because bStart.Text = 'Stop':");
                    log("Abort thread thr");
                    thr.Abort();
                    log("set status text to Aborted");
                    lStatus.Text = "Aborted";
                    lSubStatus.Text = "";
                    pbMain.Value = 0;
                    pbSub.Value = 0;
                    log("reset progres bars");
                    bStart.Text = "Start";
                    tbOutputPath.Enabled = true;
                    tbSourcePath.Enabled = true;
                    bBrowseSource.Enabled = true;
                    bOutputBrowse.Enabled = true;
                    nudIterations.Enabled = true;
                    nudChunkSize.Enabled = true;
                    log("enable buttons");
                    log("end click event");
                    return;
                }
                sourcePath = tbSourcePath.Text;
                outputPath = tbOutputPath.Text;
                log("sourcePath = " + sourcePath);
                log("outputPath = " + outputPath);
                if (!File.Exists(sourcePath))
                {
                    log("because file '" + sourcePath + "' is not exists:");
                    lStatus.Text = "Error: source path is incorrect";
                    log("set status text to '" + lStatus.Text + "'");
                    log("end click event");
                    return;
                }
                if (!Directory.Exists(outputPath))
                {
                    log("because outPutpath '" + outputPath + "' is not exists:");
                    outputPath = Directory.GetCurrentDirectory();
                    log("set outPutpath to '" + outputPath + "'");
                    tbOutputPath.Text = outputPath;
                    log("set tbOutputPath.Text to '" + tbOutputPath.Text + "'");
                }
                tbOutputPath.Enabled = false;
                tbSourcePath.Enabled = false;
                bBrowseSource.Enabled = false;
                bOutputBrowse.Enabled = false;
                nudIterations.Enabled = false;
                nudChunkSize.Enabled = false;
                log("disable input");
                log("start mainLoop on thread");
                ThreadStart thrStr = new ThreadStart(mainLoop);
                thr = new Thread(thrStr);
                thr.Start();

                bStart.Text = "Stop";
            }
            catch (Exception ex)
            {
                logException(ex);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nudChunkSize_ValueChanged(object sender, EventArgs e)
        {
            nudChunkSize.Value = nudChunkSize.Value - nudChunkSize.Value % 4;
        }
    }
}
