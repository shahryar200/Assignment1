using System;
using System.Collections;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        object[] title_4dis_cnn = new object[25];
        /* Begin to Fetch CNN news related to Trump */
        GetCNN cnn = new GetCNN();
        string node = cnn.getfnode();
        Queue links = cnn.crawl_sec_node(node);
        Queue titles = cnn.gettitleandbody(links.ToArray());
        title_4dis_cnn = titles.ToArray();
        for (int i = 0; i < 25; i++)
        {//"<a href=" + div.GetAttribute("href") + ">" + arr_title[j] + "</a>"
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            //cell.Text = "<a href=" + links.Dequeue().ToString() + ">" + titles.Dequeue().ToString() + "</a>";
            string href = "'" + links.Dequeue().ToString() + "'";
            cell.Text = "<a onClick=\"MyWindow = window.open(" + href + ", width = 600, height = 800);\">" + titles.Dequeue().ToString() + "</a>";
            cell.ID = ("cell" + i.ToString());
            row.Cells.Add(cell);
            Table1.Rows.Add(row);

            TableCell cell1 = new TableCell();
            cell1.Text = i.ToString();
            row.Cells.Add(cell1);

        }
        /* End to Fetch CNN news related to Trump */

        /* Begin to Fetch tweets of Trump */
        Gettweets a = new Gettweets();

        a.GetMostRecent25TimeLine();
        object[] title_4dis_tw = new object[25];
        int ii = 0;
        foreach (var item in a.currentTweets)
        {
            title_4dis_tw[ii] = item.Text;
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            if (item.Text.Contains("https://t.co/"))
            {
                string href = "'" + item.Text.Substring(item.Text.IndexOf("https://t.co/"), 23) + "'";
                cell.Text = "<a onClick=\"MyWindow = window.open(" + href + ", width = 600, height = 800);\">" + item.Text + "</a>";
                cell.ID = ("cell" + ii.ToString());
                row.Cells.Add(cell);
                Table2.Rows.Add(row);

                TableCell cell11 = new TableCell();
                cell11.Text = ii.ToString();
                row.Cells.Add(cell11);
            }
            else
            {
                cell.Text = item.Text;
                cell.ID = ("cell" + ii.ToString());
                row.Cells.Add(cell);
                Table2.Rows.Add(row);
                TableCell cell11 = new TableCell();
                cell11.Text = ii.ToString();
                row.Cells.Add(cell11);
            }
            ii++;
        }
        /* End to Fetch tweets of Trump */

        /* Begin compute distance between two titles */
        levenshtain_dist dis = new levenshtain_dist();
        //int[] discom = new int[25 * 25];
        int k = 0, l = 0;
        foreach (var cn_n in title_4dis_cnn)
        {
            foreach (var tw in title_4dis_tw)
            {
                if (dis.Compute(cn_n.ToString(), tw.ToString()) < 80)
                {
                    TableRow row33 = new TableRow();
                    TableCell cell33 = new TableCell();
                    cell33.Text = dis.Compute(cn_n.ToString(), tw.ToString()).ToString();
                    //cell33.ID = ("cell" + ii.ToString());
                    row33.Cells.Add(cell33);
                    Table3.Rows.Add(row33);

                    TableCell cell113 = new TableCell();
                    cell113.Text = "tweet #" + l.ToString() + "CNN #" + k.ToString();
                    row33.Cells.Add(cell113);
                }
                l++;
            }
            l = 0;
            k++;
        }

        /* End compute distance between two titles */
    }
}