using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Image = System.Web.UI.WebControls.Image;
using System.Web.UI;
//mahbub
namespace OH.Utilities
{
    public class FileUploadHelper
    {
        
        public static void BindImage(FileUpload imgaeUpload, string path, string imageName)
        {
            try
            {
                if (Path.GetExtension(imgaeUpload.FileName) != null)
                {
                    string ext = Path.GetExtension(imgaeUpload.FileName);

                    ext = ext.ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string newPath = path + imageName + ext;
                        imgaeUpload.SaveAs(newPath);
                    }
                    else
                    {
                        throw new Exception("Picture not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                    }
                }
                else
                {
                    throw new Exception("File not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }
        public static void BindImage(HttpPostedFile imgaeUpload, string path, string imageName)
        {
            try
            {
                if (Path.GetExtension(imgaeUpload.FileName) != null)
                {
                    string ext = Path.GetExtension(imgaeUpload.FileName);

                    ext = ext.ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string newPath = path + imageName + ext;
                        imgaeUpload.SaveAs(newPath);
                    }
                    else
                    {
                        throw new Exception("Picture not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                    }
                }
                else
                {
                    throw new Exception("File not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }
       
        public static void BindImage(HttpPostedFile imgaeUpload, string path, string imageName, int xResolution, int yResolution)
        {
            try
            {
                if (Path.GetExtension(imgaeUpload.FileName) != null)
                {
                    string ext = Path.GetExtension(imgaeUpload.FileName);

                    ext = ext.ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string newPath = path + imageName + ext;
                        Bitmap resizeImage = new Bitmap(ResizeImage(xResolution, yResolution,imgaeUpload));
                        resizeImage.Save(newPath);
                    }
                    else
                    {
                        throw new Exception("Picture not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static void BindImage(FileUpload imgaeUpload, string path, string imageName, int xResolution, int yResolution)
        {
            try
            {
                if (Path.GetExtension(imgaeUpload.FileName) != null)
                {
                    string ext = Path.GetExtension(imgaeUpload.FileName);

                    ext = ext.ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string newPath = path + imageName + ext;
                        Bitmap resizeImage = new Bitmap(ResizeImage(xResolution, yResolution, imgaeUpload));
                        resizeImage.Save(newPath);
                    }
                    else
                    {
                        throw new Exception("Picture not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                    }
                }
                else
                {
                    throw new Exception("File not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static void BindImageWithKeepAspectRatio(FileUpload imgaeUpload, string path, string imageName, int xResolution, int yResolution)
        {
            try
            {
                if (Path.GetExtension(imgaeUpload.FileName) != null)
                {
                    string ext = Path.GetExtension(imgaeUpload.FileName);

                    ext = ext.ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string newPath = path + imageName + ext;
                        //convert image and save
                        Bitmap resizeImage = new Bitmap(ResizeImageButKeepAspectRatio(imgaeUpload, xResolution, yResolution));
                        resizeImage.Save(newPath);
                    }
                    else
                    {
                        throw new Exception("Picture not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                    }
                }
                else
                {
                    throw new Exception("File not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
           
        }
        public static void BindImageWithKeepAspectRatio(HttpPostedFile imgaeUpload, string path, string imageName, int xResolution, int yResolution)
        {
            try
            {
                if (Path.GetExtension(imgaeUpload.FileName) != null)
                {
                    string ext = Path.GetExtension(imgaeUpload.FileName);

                    ext = ext.ToLower();
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    {
                        string newPath = path + imageName + ext;
                        //convert image and save
                        Bitmap resizeImage = new Bitmap(ResizeImageButKeepAspectRatio(imgaeUpload, xResolution, yResolution));
                        resizeImage.Save(newPath);
                    }
                    else
                    {
                        throw new Exception("Picture not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                    }
                }
                else
                {
                    throw new Exception("File not in correct format. please upload '.jpg' , '.jpeg' or '.png' format for your picture");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        //Resize Image resolution
        public static Bitmap ResizeImage(int lnWidth, int lnHeight,HttpPostedFile imageUpload)
        {
            Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(imageUpload.InputStream);
                bmpOut = reSize(loBMP, lnWidth, lnHeight);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return bmpOut;
        }
        public static Bitmap ResizeImage(int lnWidth, int lnHeight, FileUpload imageUpload)
        {
            Bitmap bmpOut = null;
            try
            {
                Bitmap loBMP = new Bitmap(imageUpload.FileContent);
                bmpOut = reSize(loBMP, lnWidth, lnHeight);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return bmpOut;
        }

        public static Bitmap reSize(Bitmap loBMP, int lnWidth, int lnHeight)
        {
            Bitmap bmpOut = null;
            try
            {
                ImageFormat loFormat = loBMP.RawFormat;

                bmpOut = new Bitmap(lnWidth, lnHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.FillRectangle(Brushes.White, 0, 0, lnWidth, lnHeight);
                g.DrawImage(loBMP, 0, 0, lnWidth, lnHeight);

                loBMP.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return bmpOut;
        }

        public static Bitmap ResizeImageButKeepAspectRatio(FileUpload imageUpload, int lnWidth, int lnHeight)
        {

            Bitmap bmpOut = null;

            try
            {
                Bitmap loBMP = new Bitmap(imageUpload.FileContent);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }


                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                bmpOut= reSize(bmpOut, lnNewWidth, lnNewHeight);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return bmpOut;
        }
        public static Bitmap ResizeImageButKeepAspectRatio(HttpPostedFile imageUpload, int lnWidth, int lnHeight)
        {

            Bitmap bmpOut = null;

            try
            {
                Bitmap loBMP = new Bitmap(imageUpload.InputStream);
                ImageFormat loFormat = loBMP.RawFormat;

                decimal lnRatio;
                int lnNewWidth = 0;
                int lnNewHeight = 0;

                if (loBMP.Width < lnWidth && loBMP.Height < lnHeight)
                    return loBMP;

                if (loBMP.Width > loBMP.Height)
                {
                    lnRatio = (decimal)lnWidth / loBMP.Width;
                    lnNewWidth = lnWidth;
                    decimal lnTemp = loBMP.Height * lnRatio;
                    lnNewHeight = (int)lnTemp;
                }
                else
                {
                    lnRatio = (decimal)lnHeight / loBMP.Height;
                    lnNewHeight = lnHeight;
                    decimal lnTemp = loBMP.Width * lnRatio;
                    lnNewWidth = (int)lnTemp;
                }


                bmpOut = new Bitmap(lnNewWidth, lnNewHeight);
                bmpOut = reSize(bmpOut, lnNewWidth, lnNewHeight);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return bmpOut;
        }


        public static void Bind(FileUpload fileUpload, string path, string fileName)
        {
            try
            {
                string newPath = path + fileName + Path.GetExtension(fileUpload.FileName);
                fileUpload.SaveAs(newPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
          
        }

    }
}
