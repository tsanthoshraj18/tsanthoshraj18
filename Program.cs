﻿using AForge.Video.FFMPEG;
using System;
using System.Drawing;
using System.IO;

namespace TimeLapseCreator
{
    class Program
    {
        //Enter the Path here
        const string basePath = @"E:\Pic\NIFTY-22-JUL-2021\";

        static void Main(string[] args)
        {


            using (var videoWriter = new VideoFileWriter())
            {
                //video path + and video format, Image Width , Hieght , Bitdepth
                videoWriter.Open(basePath + "Output.avi", 1536, 742, 12, VideoCodec.MPEG4, 1000000);

                //Enter the Image format 
                var image = Directory.GetFiles(basePath, "*.png");

                foreach (var images in image)


                {

                    using (Bitmap bitImage = Bitmap.FromFile(images) as Bitmap)
                    {
                        videoWriter.WriteVideoFrame(bitImage);
                    }

                }
                videoWriter.Close();


            }
            //Console.WriteLine("Process Completed Sucessfully...");


        }
    }
}