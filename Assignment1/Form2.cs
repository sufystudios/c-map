using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Google.Maps;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class QuestionForm : Form
    {
        Form root;
        private int x, y;
        object clickeditem;
        LatLng currentlatlng;
        PointLatLng pp;
        GMapMarker mark;
        public QuestionForm(Form f, object sender)
        {
            InitializeComponent();
            clickeditem = sender;
            root = f;
            MainForm form1 = (MainForm)root;
            Console.WriteLine(sender.GetType());
            if (sender.GetType() == typeof(GMarkerGoogle))
            {
                mark = (GMapMarker)sender;
                addEvent.Hide();
                EventType.Hide();
                // filetext.Hide();
                button1.Hide();
                addToTrack.Hide();
                eventypelabel.Hide();
                tracklogID.Hide();
            }
            else
            {


                update.Hide();
                delete.Hide();
            }

        }
        public void setRoot(Form root)
        {
            this.root = root;
        }
        public Form getRoot()
        {
            return root;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            AddXML.removeEvent(Event.getIndex((GMapMarker)mark));
            Console.WriteLine(Event.getIndex((GMapMarker)mark));
            ((MainForm)root).removeMarker(mark);
            Close();
        }
        public void AddCoords(PointLatLng ll)
        {
            pp = ll;

        }

        private void center_Click(object sender, EventArgs e)
        {
            // ((MainForm)root).setLatLng(currentlatlng);
            Console.WriteLine(currentlatlng);
            this.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            AddXML.updateEvent(mark, message.Text);
            this.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Connect_Click(object sender, EventArgs e)
        {
            ((MainForm)root).drawLine(Event.getIndex(mark), Int32.Parse(connectID.Text));
            AddXML.addConnection(Event.getIndex(mark), Int32.Parse(connectID.Text));
            (root).Refresh();
            ((MainForm)root).GetGMapControl().Refresh();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                filetext.Text = filedialog.FileName;
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void addEvent_Click(object sender, EventArgs e)
        {
            MainForm f = (MainForm)root;
            // Console.WriteLine("testing");
            // Label l=  new Label();
            // l.Text = "HI";
            //  l.Location = new Point(PositionSystem.Instance().X, PositionSystem.Instance().Y);
            //l.MouseClick+=new System.Windows.Forms.MouseEventHandler(f.panel1_MouseClick);
            //  Random rnd = new Random();
            //  Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            //  l.BackColor = randomColor;
            int id = AddXML.AddToFile(EventType.Text, message.Text, pp, filetext.Text);
            if (EventType.Text == "photo")
            {
                ((MainForm)root).addMarkerImage(id, pp.Lat, pp.Lng, filetext.Text, EventType.Text);
            }
            else if (EventType.Text == "tracklog")
            {
                ((MainForm)root).addTracklog(id, AddXML.LoadGPXWaypoints(filetext.Text) + AddXML.LoadGPXTracks(filetext.Text));
            }
            else if (EventType.Text == "video")
            {
                ((MainForm)root).addMarkerVideo(id, pp.Lat, pp.Lng, filetext.Text, EventType.Text);
            }
            else
                ((MainForm)root).addMarker(id, pp.Lat, pp.Lng, message.Text, EventType.Text);
            //f.getPanel().Controls.Add(l);
            // int zIndex = f.getPanel().Controls.GetChildIndex(l);
            //  l.BringToFront();
            // Do something...
            // Then send it back again
            //f.showMap();
            //f.getPanel().Controls.SetChildIndex(l, zIndex +1 );

            this.Close();
        }
    }
}
