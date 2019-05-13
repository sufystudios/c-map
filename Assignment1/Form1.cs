using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Google.Maps;
using Google.Maps.StaticMaps;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class MainForm : Form
    {
        StaticMapRequest map;
        private int depth;
        private string address = "";
            private string defaultx = "";
            private string defaulty = "";
        private string responsestring;
        private int zoom=9;
        private double lat = -32.0258301;
        private double lng = 115.9149175;
        private string key = "AIzaSyCY4LFVRilOWUScUH6DK5SORNMOxzJD0Fg";
        string defaultzoom;
       // private List<Label> labels;
       // private List<GMapMarker> markers;
        private Random rnd = new Random();
        private double totallong;
        private double totallat;
        private double swlat;
        private double swlon;
        private double nelat;
        private double nelon;
        private Dictionary<int,GMapMarker> markers;
        private GMapControl gmap;
        private GMapOverlay overlay;
        public MainForm()
        {
            InitializeComponent();
            gmap = new GMapControl();
            this.Controls.Add(gmap);
            gmap.BringToFront();

            gmap.MapProvider = GMapProviders.GoogleMap;
            
            gmap.MinZoom = 2;
            gmap.MaxZoom = 100;
            depth = 0;
            overlay = new GMapOverlay();
            gmap.Overlays.Add(overlay);
          //  labels = new List<Label>();
            gmap.Dock = DockStyle.Fill;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            markers = new Dictionary<int, GMapMarker>();

            //showMap();
            Size size;
         
         
            gmap.OnMarkerClick += marker_Click;
         
            gmap.DisableFocusOnMouseEnter = true;
            // offsets
           // gmap.OnMarkerEnter += markermouseover;
          //  panel1.BackgroundImageLayout = ImageLayout.Center;
            defaultzoom = zoom.ToString();
            Console.WriteLine(defaultx + defaulty);
           // address = "https://maps.googleapis.com/maps/api/staticmap?center="+lat.ToString()+","+lng.ToString()+"&zoom=" + defaultzoom+"&scale=1"+"&size="+defaultx+"x"+defaulty+"&key="+key;
           // panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            gmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            //gmap.Position = new PointLatLng(lat,lng);
            gmap.SetPositionByKeywords("Sydney, Australia");
            gmap.Zoom = zoom;
            // panel1.MouseWheel+=mousewheel;
           // this.MouseWheel += mousewheel;
            // pictureBox1.MouseClick+=new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            showMap();
            loadXMLThings();
            // form2.Parent = this;
            panel1.BringToFront();
        }
       private void loadXMLThings()
        {

        }

        private Point getPositionOnScreen(double longitude, double latitude)
        {


            // offsets
            double mapLongitudeStart , mapLatitudeStart ;
            // length of map in long/lat
            double mapLongitude,
                    // invert because it decreases as you go down
                    mapLatitude;
        
     
            // set x & y using conversion
        
            LatLng bottom = getLatLng(lat,//center-latitude of the static-map
              lng,//center-longitude of the static-map
             zoom,//zoom of the static-map
              Int32.Parse(defaultx),//width of the static-map
             Int32.Parse(defaulty),//height of the static-map
            0,//x-coordinate of the mouseevent inside the element
            0//y-coordinate of the mouseevent inside the element

              );
            LatLng top = getLatLng(lat,//center-latitude of the static-map
             lng,//center-longitude of the static-map
            zoom,//zoom of the static-map
             Int32.Parse(defaultx),//width of the static-map
            Int32.Parse(defaulty),//height of the static-map
           Int32.Parse(defaultx),//x-coordinate of the mouseevent inside the element
           Int32.Parse(defaulty)//y-coordinate of the mouseevent inside the element

             );
            bottom = new LatLng(swlat, swlon);
            top = new LatLng(nelat, nelon);
            
            //Console.WriteLine("longitude" + longitude);
           
            mapLongitudeStart = bottom.Longitude;
            //Console.WriteLine("long start" +mapLongitudeStart);
            mapLatitudeStart = bottom.Latitude;
           // Console.WriteLine("lat start" +mapLatitudeStart);
           
            mapLongitude = top.Longitude - mapLongitudeStart;
            mapLatitude = mapLatitudeStart - top.Latitude;
            totallong = mapLongitude;
            totallat = mapLatitude;
           // Console.WriteLine("map long" +mapLongitude);
            //Console.WriteLine("map lat"+mapLatitude);
       
           // Console.WriteLine(mapLongitudeStart + "test" + longitude);
            longitude = longitude-mapLongitudeStart;
           // Console.WriteLine(lonToX(longitude, zoom));
           // Console.WriteLine("longitude" + longitude);
           // Console.WriteLine(mapLongitudeStart + "test" + longitude);
            // do inverse because the latitude increases as we go up but the y decreases as we go up.
            // if we didn't do the inverse then all the y values would be negative.
            latitude = mapLatitudeStart - latitude;
    
         //   Console.WriteLine("latitude" + latitude);
            int x = (int)(double.Parse(defaultx) * (double)((double)longitude / (double)mapLongitude));
            int y = (int)(double.Parse(defaulty) * (double)((double)latitude / (double)mapLatitude));
            // Console.WriteLine("latlong" + latitude + " " + longitude);
            //  Console.WriteLine((double)longitude);
          //  Console.WriteLine("testing123" + latitude+" "+latToY(latitude, zoom));
            return new Point(x, y);
        }
        public void mousewheel(Object Sender,MouseEventArgs e) 
        {
            
            {

             
                    zoom += (e.Delta / 120);

                Console.WriteLine(e.Delta / 120);
                gmap.Zoom = zoom;
               // address = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat.ToString() + "," + lng.ToString() + "&zoom=" + zoom.ToString() + "&scale=1" + "&size=" + defaultx + "x" + defaulty + "&key=" + key;
                //showMap();
            }

        }
        public void removeMarker(GMapMarker mark)
        {
            overlay.Markers.Remove(mark);
        }
        public static Bitmap GetThumbnail(string video, string thumbnail)
        {
            var cmd = "ffmpeg  -itsoffset -1  -i " + '"' + video + '"' + " -vcodec mjpeg -vframes 1 -an -f rawvideo -s 320x240 " + '"' + thumbnail + '"';

            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C " + cmd
            };

            var process = new Process
            {
                StartInfo = startInfo
            };

            process.Start();
            process.WaitForExit(5000);

            return LoadImage(thumbnail);
        }
        static Bitmap LoadImage(string path)
        {
            var ms = new MemoryStream(File.ReadAllBytes(path));
            return (Bitmap)Image.FromStream(ms);
        }
        public void drawLine(int from, int to)
        {
            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(markers[from].Position.Lat,markers[from].Position.Lng));
            points.Add(new PointLatLng(markers[to].Position.Lat,markers[to].Position.Lng));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red, 1);
            polyOverlay.Polygons.Add(polygon);
            gmap.Overlays.Add(polyOverlay);
        }
        public void drawLineTrack(double latf,double lonf, double lat, double lon)
        {
            GMapOverlay polyOverlay = new GMapOverlay("polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(latf, lonf));
            points.Add(new PointLatLng(lat, lon));
            GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Green));
            polygon.Stroke = new Pen(Color.Green, 1);
            polyOverlay.Polygons.Add(polygon);
            gmap.Overlays.Add(polyOverlay);
        }
        private int MouseXGet(double lat)
        {
            var tiles = 1 << zoom;
            var mousepointx=(((double)lat*(double)tiles) -(double)128) / ((double)256 / (double)360);
            // var mousex=((double)centerPointx * (double)tiles) + (double)x;
        
            return (int)(mousepointx);
            return 0;
        }
        private LatLng getLatLng(double lat,//center-latitude of the static-map
              double lng,//center-longitude of the static-map
              int zoom,//zoom of the static-map
              int width,//width of the static-map
              int height,//height of the static-map
              int mouseX,//x-coordinate of the mouseevent inside the element
              int mouseY//y-coordinate of the mouseevent inside the element

              )
        {


            var x = mouseX - (width / 2);
           var y = mouseY - (height / 2); 
              var  s = Math.Min(Math.Max(Math.Sin(lat * (Math.PI / 180)), -.9999), .9999);
                var tiles = 1 << zoom;
                double centerPointx = 128 + lng * ((double)256 / (double)360),
                    centerPointy = 128 + 0.5 * Math.Log((1 + s) / (1 - s)) * -(256 / (2 * Math.PI));
            var 
            mousePointx = ((double)centerPointx * (double)tiles) + (double)x;
            var mousePointy = (centerPointy * tiles) + y;
          //  Console.WriteLine(mousePointx);
           // Console.WriteLine(128 + lng * ((double)256 / (double)360));
            //Console.WriteLine(s);
            var mouselat = (2 * Math.Atan(Math.Exp(((mousePointy / tiles) - 128)
                                        / -(256 / (2 * Math.PI)))) -
                            Math.PI / 2) / (Math.PI / 180);
                  var  mouselng=((((double)mousePointx/(double)tiles) - (double)128) / ((double)256 / (double)360));
            LatLng stuff = new LatLng(mouselat,mouselng);
           
      return stuff;

    }
        public int lonToX(double lon, int zoom)
        {
            int offset = 256 << (zoom - 1);
            return (int)Math.Round(offset + (offset * lon / 180));
        }

        public int latToY(double lat, int zooml)
        {
            int offset =256 << (zooml - 1);
            return (int)Math.Round(offset - offset / Math.PI * Math.Log((1 + Math.Sin(lat * Math.PI / 180)) / (1 - Math.Sin(lat * Math.PI / 180))) / 2);
        }
        public void addMarker(int id,double lat, double lon, string message,string type)
        {
            PointLatLng point = new PointLatLng(lat, lon);
            GMapMarker marker= new GMarkerGoogle(point, GMarkerGoogleType.pink);
            if (type=="tweet")
            {
                Bitmap bm = (Bitmap)Image.FromFile("bird.png");
               
                Bitmap scaled = new Bitmap(bm, new Size(40, 40));
                marker = new GMarkerGoogle(point, scaled);
            } else if(type=="facebook-status-update")
            {
                Bitmap bm = (Bitmap)Image.FromFile("fb.png");
                Bitmap scaled = new Bitmap(bm, new Size(25, 25));
                marker = new GMarkerGoogle(point, scaled);
            } else
                marker= new GMarkerGoogle(point, GMarkerGoogleType.pink);
            overlay.Markers.Add(marker);
            markers[id] = marker;
            marker.ToolTipText = id.ToString()+":"+type+ " :"+message;
            marker.ToolTipMode = MarkerTooltipMode.Always;
            

        }
        public void addMarkerImage(int id, double lat, double lon, string filename, string type)
        {
            PointLatLng point = new PointLatLng(lat, lon);
            try
            {
                Bitmap bm;
                try
                {
                    bm = (Bitmap)Image.FromFile(filename);
                } catch(Exception e)
                {
                    bm = (Bitmap)Image.FromFile("default-photo.png");
                }
                    Bitmap scaled= new Bitmap(bm, new Size(50,50));
               
                GMapMarker marker = new GMarkerGoogle(point, scaled);
                overlay.Markers.Add(marker);
                markers[id] = marker;
                marker.ToolTipText = id.ToString() + ":" + type + " :" ;
                marker.ToolTipMode = MarkerTooltipMode.Always;
            } catch (Exception e)
            {
                
            }

        }
        public void addMarkerVideo(int id, double lat, double lon, string filename, string type)
        {
            PointLatLng point = new PointLatLng(lat, lon);
            try
            {


                Bitmap bm = (Bitmap)Image.FromFile("video-file.png"); //(Bitmap)Image.FromFile("video-file.png");
                Bitmap scaled = new Bitmap(bm, new Size(50, 50));

                GMapMarker marker = new GMarkerGoogle(point, scaled);
                overlay.Markers.Add(marker);
                markers[id] = marker;
                marker.ToolTipText = id.ToString() + ":" + type + " :";
                marker.ToolTipMode = MarkerTooltipMode.Always;
            }
            catch (Exception e)
            {

            }

        }
        public void showMap()
        {
            try
            {
              
                var events = AddXML.getXMLEvents();
                
              
                //markers = new List<GMapMarker>();
                //labels = new List<Label>();
               
              
                foreach (var item in events)
                {
                    // Point p = getPositionOnScreen(item.lon, item.lat);
                    addMarker(item.id, item.lat, item.lon, item.message,item.type);
                   /* PointLatLng point = new PointLatLng(item.lat,item.lon);
                    GMapMarker marker = new GMarkerGoogle(point,GMarkerGoogleType.pink);
                    overlay.Markers.Add(marker);
                    marker.ToolTipText =item.id+ item.message;
                    marker.ToolTipMode = MarkerTooltipMode.Always;
                    */
                   
                    
                }
                var tracklogs = AddXML.getTracklogs();
                foreach (var item in tracklogs)
                {
                    addTracklog(item.id, item.data);
                }
                var photos = AddXML.getXMLPhotos();
                foreach (var item in photos)
                {
                    Console.WriteLine("test");
                    // Point p = getPositionOnScreen(item.lon, item.lat);
                    addMarkerImage(item.id, item.lat, item.lon, item.filename, item.type);
                    /* PointLatLng point = new PointLatLng(item.lat,item.lon);
                     GMapMarker marker = new GMarkerGoogle(point,GMarkerGoogleType.pink);
                     overlay.Markers.Add(marker);
                     marker.ToolTipText =item.id+ item.message;
                     marker.ToolTipMode = MarkerTooltipMode.Always;
                     */


                }
                var videos = AddXML.getXMLVideos();
                foreach (var item in videos)
                {
                    Console.WriteLine(item.type);

                    // Point p = getPositionOnScreen(item.lon, item.lat);
                    addMarkerVideo(item.id, item.lat, item.lon, item.filename, item.type);
                    /* PointLatLng point = new PointLatLng(item.lat,item.lon);
                     GMapMarker marker = new GMarkerGoogle(point,GMarkerGoogleType.pink);
                     overlay.Markers.Add(marker);
                     marker.ToolTipText =item.id+ item.message;
                     marker.ToolTipMode = MarkerTooltipMode.Always;
                     */


                }
                doConnections();
               
            }
            catch (Exception e)
            {
                Console.WriteLine("couldn't download" + e);
            }
        }
        public void addTracklog(int id, string data)
        {
            List<double[]> stuff=AddXML.getWaypoints(data);
            for(int i=0;i<stuff.Count;i++)
            {
                if (i == 0)
                {
                    addMarker(id, stuff[i][0], stuff[i][1], "", "tracklog");
                }
                else
                {
                    drawLineTrack(stuff[i-1][0], stuff[i-1][1],stuff[i][0],stuff[i][1]);
                }
            }
        }
        public void doConnections()
        {
            
            foreach(var keys in markers)
            {
                var connections = AddXML.GetConnections(keys.Key);
                if (connections != null)
                {
                    foreach (var item in connections)
                    {
                        Console.WriteLine("in connections" + item.from);
                        drawLine(item.from, item.to);
                    }
                }
            }
          
        }
        public void markermouseover(object sender, EventArgs e)
        {

        }
     
 
    
           public void marker_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right )
            {
                Form form2 = new QuestionForm(this, sender);
                Console.WriteLine("test");
                form2.Show();
            }
        }
      public GMapControl GetGMapControl()
        {
            return gmap;
        }
        public void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button ==MouseButtons.Left)
            {
                Form form2 = new QuestionForm(this, sender);
                //textBox1.Text = string.Format("X: {0} , Y: {1}", Cursor.Position.X, Cursor.Position.Y);
                Point p = new Point(e.Location.X, e.Location.Y);

                //textBox1.Text = p.ToString();
                // PositionSystem.Instance().X = p.X;
                // PositionSystem.Instance().Y = p.Y;
                PointLatLng pp=gmap.FromLocalToLatLng(e.Location.X,e.Location.Y);
               
               // Point test = getPositionOnScreen(stuff.Longitude, stuff.Latitude);

                // Console.WriteLine("lat:" + stuff.Latitude.ToString() + "lng" +stuff.Longitude.ToString());
                //Console.WriteLine(stuff.ToString());
                ((QuestionForm)form2).AddCoords(pp);
                form2.Show();
            }

            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (zooml.Text != "")
                gmap.Zoom = Int32.Parse(zooml.Text);
            gmap.SetPositionByKeywords(location.Text);
            
            Console.WriteLine(gmap.Position);
            //gmap.Refresh();
            Console.WriteLine(location.Text);
        }
    }
}
