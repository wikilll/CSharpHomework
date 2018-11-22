using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Program1
{
    class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);

            //new Thread(myCrawler.Crawl).Start();
            Action[] actions = { new Action(myCrawler.Crawl), myCrawler.Crawl };
            Parallel.Invoke(actions);

        }

        private void Crawl()
        {

            Console.WriteLine("开始爬行了....");



            //    Task[] tasks = new Task[10];
            //    tasks[count] = new TaskFactory().StartNew(() =>
            //    {
            //        foreach (string url in urls.Keys)
            //        {
            //            if ((bool)urls[url]) continue;
            //            current = url;
            //        }
            ////Download(current);
            //Console.WriteLine("爬行" + current + "页面!");
            //        html = Download(current);
            //        urls[current] = true;
            //        count++;
            //        Parse(html);
            //    });
            //Task.WaitAll(tasks);

            //Thread[] downloadThread = new Thread[5];
            //for (int i = 0; i < downloadThread.Length; i++)
            //{
            //    ThreadStart startDownload = new ThreadStart(() =>
            //    {
            //        current = ss;
            //        foreach (string url in urls.Keys)
            //        {
            //            if ((bool)urls[url]) continue;
            //            current = url;
            //        }
            //        Console.WriteLine("爬行" + current + "页面!");
            //        html = Download(current);
            //        urls[current] = true;
            //        count++;
            //        Parse(html);

            //    });
            //    downloadThread[i] = new Thread(startDownload);
            //    downloadThread[i].Start();
            //}

            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }
                if (current == null || count > 10) break;

                Console.WriteLine("爬行" + current + "页面!");

                string html = Download(current);
                urls[current] = true;
                count++;
                Parse(html);
            }
            Console.WriteLine("爬行结束");
            //Thread.Sleep(2000);
        }

        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = @"..\..\" + count.ToString() + ".txt";
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href | HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                if (strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
