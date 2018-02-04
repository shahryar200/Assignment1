using System.Collections;
using System.Net;
using System.Xml;

/// <summary>
/// Summary description for GetCNN
/// </summary>
public class GetCNN
{
    public GetCNN()
    { }
    public string getfnode()
    {
        string baseurl = "http://edition.cnn.com/sitemaps/sitemap-index.xml";
        /*Create a new instance of the System.Net Webclient*/
        WebClient wc = new WebClient();
        /*Set the Encodeing on the Web Client*/
        wc.Encoding = System.Text.Encoding.UTF8;
        /* Download the document as a string*/
        string reply = wc.DownloadString(baseurl);
        /*Create a new xml document*/
        XmlDocument urldoc = new XmlDocument();
        /*Load the downloaded string as XML*/
        urldoc.LoadXml(reply);
        /*Create an list of XML nodes from the url nodes in the sitemap*/
        XmlNodeList xnList = urldoc.GetElementsByTagName("sitemap");
        /*Loops through the node list and prints the values of each node*/

        string sitenode = "";
        foreach (XmlNode node in xnList)
        {

            if (node["loc"].InnerText.Contains("articles"))
            {
                sitenode = node["loc"].InnerText;
                break;
            }
        }

        return sitenode;
    }

    public Queue crawl_sec_node(string url)
    {
        string baseurl = url;
        /*Create a new instance of the System.Net Webclient*/
        WebClient wc = new WebClient();
        /*Set the Encodeing on the Web Client*/
        wc.Encoding = System.Text.Encoding.UTF8;
        /* Download the document as a string*/
        string reply = wc.DownloadString(baseurl);
        /*Create a new xml document*/
        XmlDocument urldoc = new XmlDocument();
        /*Load the downloaded string as XML*/
        urldoc.LoadXml(reply);
        /*Create an list of XML nodes from the url nodes in the sitemap*/
        XmlNodeList xnList = urldoc.GetElementsByTagName("url");
        /*Loops through the node list and prints the values of each node*/

        //string[] sitenode=new string[1]; /html/body/div[4]/article/div[1]/h1
        Queue sitenode1 = new Queue();
        foreach (XmlNode node in xnList)
        {

            if (node["loc"].InnerText.Contains("trump"))
            {
                if (node["loc"].InnerText.Contains("politics"))
                {
                    sitenode1.Enqueue(node["loc"].InnerText);

                }
                //sitenode[i] = node["loc"].InnerText;
            }
            else
            {
                if (crawl_webpage(node["loc"].InnerText))
                {
                    if (node["loc"].InnerText.Contains("politics"))
                    {
                        sitenode1.Enqueue(node["loc"].InnerText);
                    }
                    //sitenode[i] = node["loc"].InnerText;
                }
            }
            if (sitenode1.Count == 25)
            {
                return sitenode1;
            }
        }
        return sitenode1;

    }



    public bool crawl_webpage(string url)
    {//*[@id="body-text"]
        HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc = web.Load(url);
        var mtn = doc.DocumentNode.SelectSingleNode("//*[@id='body-text']");
        if (url.Contains("politics"))
        {
            if (mtn.InnerText.ToString().Contains("Trump"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public Queue gettitleandbody(object[] url1)
    {
        Queue sitenode2 = new Queue();
        foreach (var items in url1)
        {
            HtmlAgilityPack.HtmlWeb web1 = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc1 = web1.Load(items.ToString());
            var mtn1 = doc1.DocumentNode.SelectSingleNode("/html/head/title");///html/body/div[5]/article/div[1]/h1[@class='pg-headline']");
            sitenode2.Enqueue(mtn1.InnerText.ToString());
        }
        return sitenode2;
    }
}