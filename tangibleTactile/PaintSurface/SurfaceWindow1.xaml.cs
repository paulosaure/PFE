using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PaintSurface
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {

        private bool brosseadentBool = false, verreBool = false, dentifriceBool = false;
        //private SocketManager _sm;
        //Vue choix lieu
        private MediaPlayer poubelle = new MediaPlayer();
        private MediaPlayer cuisine = new MediaPlayer();
        private MediaPlayer salon = new MediaPlayer();
        private MediaPlayer salledebain = new MediaPlayer();

        //Vue actions
        private MediaPlayer coiffez = new MediaPlayer();
        private MediaPlayer rasez = new MediaPlayer();
        private MediaPlayer brossezdent = new MediaPlayer();
        private MediaPlayer douchez = new MediaPlayer();

        //Vue objets
        private MediaPlayer brosseadentSon = new MediaPlayer();
        private MediaPlayer dentifriceSon = new MediaPlayer();
        private MediaPlayer verreSon = new MediaPlayer();
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(Window1_Closing);
            //les sons
            try
            {
                poubelle.Open(new Uri(@"\Resources\cuisine.wav", UriKind.Relative));
                cuisine.Open(new Uri(@"\Resources\cuisine.wav", UriKind.Relative));
                salon.Open(new Uri(@"Resources\salon.wav", UriKind.Relative));
                salledebain.Open(new Uri(@"Resources\salledebain.wav", UriKind.Relative));
                coiffez.Open(new Uri(@"Resources\coiffez.wav", UriKind.Relative));
                rasez.Open(new Uri(@"Resources\rasez.wav", UriKind.Relative));
                douchez.Open(new Uri(@"Resources\douchez.wav", UriKind.Relative));
                brossezdent.Open(new Uri(@"Resources\brossezlesdents.wav", UriKind.Relative));
                brosseadentSon.Open(new Uri(@"Resources\sonBrosseDent.wav", UriKind.Relative));
                dentifriceSon.Open(new Uri(@"Resources\sonDentifrice.wav", UriKind.Relative));
                verreSon.Open(new Uri(@"Resources\sonVerre.wav", UriKind.Relative));
            }
            catch (System.Exception e) { Trace.WriteLine("EXECPTION = " + e); }
            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }

         

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void touchez_Click(object sender, RoutedEventArgs e)
        {
            myGrid.Visibility = Visibility.Hidden;
            maison.Visibility = Visibility.Visible;

            animeMaison();
        }

        private async void animeMaison()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.To = 1.2;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            da.AutoReverse = true;

            await Task.Delay(1000);
            cuisineScale.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            cuisineScale.BeginAnimation(ScaleTransform.ScaleYProperty, da);
            try
            {
                poubelle.Play();
                cuisine.Play();
            }
            catch (System.Exception e) { Trace.WriteLine("execption = " +e); }

            await Task.Delay(2000);
            salonScale.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            salonScale.BeginAnimation(ScaleTransform.ScaleYProperty, da);
            try
            {
                salon.Play();
            }
            catch (System.Exception e) { Trace.WriteLine("execption = " + e); }

            await Task.Delay(2000);
            salledebainScale.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            salledebainScale.BeginAnimation(ScaleTransform.ScaleYProperty, da);
            try{
                salledebain.Play();
            }
            catch (System.Exception e) { Trace.WriteLine("execption = " + e); }
        }

        private async void animeSalleDeBain()
        {
            DoubleAnimation da = new DoubleAnimation();
            da.To = 1.2;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            da.AutoReverse = true;

            await Task.Delay(1000);
            brosseadentScale.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            brosseadentScale.BeginAnimation(ScaleTransform.ScaleYProperty, da);
            try {
                brossezdent.Play();
            }
            catch (System.Exception e) { Trace.WriteLine("execption = " + e); }
            await Task.Delay(2000);
            brosseacheveuxScale.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            brosseacheveuxScale.BeginAnimation(ScaleTransform.ScaleYProperty, da);
            try{
                coiffez.Play();
            }
            catch (System.Exception e) { Trace.WriteLine("execption = " + e); }
            await Task.Delay(2000);
            rasoirScale.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            rasoirScale.BeginAnimation(ScaleTransform.ScaleYProperty, da);
            try {
                rasez.Play();
            }
            catch (System.Exception e) { Trace.WriteLine("execption = " + e); }
            await Task.Delay(2000);
            doucheScale.BeginAnimation(ScaleTransform.ScaleXProperty, da);
            doucheScale.BeginAnimation(ScaleTransform.ScaleYProperty, da);
            try{
                douchez.Play();
            }
            catch (System.Exception e) { Trace.WriteLine("execption = " + e); }
        }
        private void ScatterViewDrop(object sender, SurfaceDragDropEventArgs e)
        {
            ImageSource i = new BitmapImage(new Uri(e.Cursor.Data as String));

            fleche.Source = i;
        }

        private void ScatterViewItemHoldGesture(object sender, TouchEventArgs e)
        {

        }

        private void salledabain_Click(object sender, RoutedEventArgs e)
        {
            cuisine.Stop();
            salon.Stop();
            salledebain.Stop();
            cuisine = null;
            salon = null;
            salledebain = null;

            maison.Visibility = Visibility.Hidden;
            atelier.Visibility = Visibility.Visible;
            animeSalleDeBain();
        }

        private async void brosseadent_Click(object sender, RoutedEventArgs e)
        {
            brossezdent.Stop();
            rasez.Stop();
            coiffez.Stop();
            douchez.Stop();
            brossezdent = null;
            rasez = null;
            coiffez = null;
            douchez = null;

            atelier.Visibility = Visibility.Hidden;
            objet.Visibility = Visibility.Visible;
            
            //Objet en Texte
            await Task.Delay(3000);
            brosseDent.Source = new BitmapImage(new Uri("/Resources/brosseadents.png", UriKind.Relative));
            dentifrice.Source = new BitmapImage(new Uri("/Resources/dentifrice.png", UriKind.Relative));
            verre.Source = new BitmapImage(new Uri("/Resources/verre.png", UriKind.Relative));
            brosseDent2.Source = new BitmapImage(new Uri("/Resources/brosseadents.png", UriKind.Relative));
            dentifrice2.Source = new BitmapImage(new Uri("/Resources/dentifrice.png", UriKind.Relative));
            verre2.Source = new BitmapImage(new Uri("/Resources/verre.png", UriKind.Relative));

            //Objet en Image
            await Task.Delay(3000);
            brosseDent.Source = new BitmapImage(new Uri("/Resources/brosse_grandT.png", UriKind.Relative));
            dentifrice.Source = new BitmapImage(new Uri("/Resources/dentifrice_grand.png", UriKind.Relative));
            verre.Source = new BitmapImage(new Uri("/Resources/verre_grand.png", UriKind.Relative));
            brosseDent2.Source = new BitmapImage(new Uri("/Resources/brosse_grandT.png", UriKind.Relative));
            dentifrice2.Source = new BitmapImage(new Uri("/Resources/dentifrice_grand.png", UriKind.Relative));
            verre2.Source = new BitmapImage(new Uri("/Resources/verre_grand.png", UriKind.Relative));
            //Objet Son
            await Task.Delay(3000);
            try
            {
                brosseadentSon.Play();
            }
            catch (System.NullReferenceException) { }

            await Task.Delay(2000);
            try
            {
                dentifriceSon.Play();
            }
            catch (System.NullReferenceException) { }

            await Task.Delay(2000);
            try
            {
                verreSon.Play();
            }
            catch (System.NullReferenceException) { }
        }

        private void brosseacheveux_Click(object sender, RoutedEventArgs e)
        {

        }

        private void douche_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rasoir_Click(object sender, RoutedEventArgs e)
        {

        }
        private void valideObjet(){

            if (brosseadentBool && verreBool && dentifriceBool)
            {
                aideTop.Visibility = Visibility.Hidden;
                aideBot.Visibility = Visibility.Hidden;
                ordonnancement.Visibility = Visibility.Visible;
            }
        }
        private void createImageVerre(Point p)
        {
             i = new Image();
            i.Width = 200;
            i.Height = 200;
            i.Source = new BitmapImage(new Uri("/Resources/rincer_bouche.png", UriKind.Relative));
            i.SetValue(Canvas.LeftProperty, p.X-110);
            i.SetValue(Canvas.TopProperty, p.Y-230);
            canvas.Children.Add(i);

            i2 = new Image();
            i2.Width = 200;
            i2.Height = 200;
            i2.Source = new BitmapImage(new Uri("/Resources/cracher.png", UriKind.Relative));
            i2.SetValue(Canvas.LeftProperty, p.X-110);
            i2.SetValue(Canvas.TopProperty, p.Y+30);
            canvas.Children.Add(i2);
        }
         private Image i,i2,i3,i4,i5,i6;
        private void createImageDentifrice(Point p)
        {
            i3 = new Image();
            i3.Width = 200;
            i3.Height = 200;
            i3.Source = new BitmapImage(new Uri("/Resources/mettre_dentifrice.png", UriKind.Relative));
            i3.SetValue(Canvas.LeftProperty, p.X - 110);
            i3.SetValue(Canvas.TopProperty, p.Y - 230);
            i3.TouchMove += i3_TouchMove;
            canvas.Children.Add(i3);

        }
        private Image imgTmp;
        void i3_TouchMove(object sender, TouchEventArgs e)
        {
            Trace.WriteLine("touch down img");
            imgTmp = i3;
            
        }
       
        private void createImageBrosse(Point p)
        {
            i4 = new Image();
            i4.Width = 200;
            i4.Height = 200;
            i4.Source = new BitmapImage(new Uri("/Resources/mouiller_brosse.png", UriKind.Relative));
            i4.SetValue(Canvas.LeftProperty, p.X +110);
            i4.SetValue(Canvas.TopProperty, p.Y - 130);
            canvas.Children.Add(i4);

            i5 = new Image();
            i5.Width = 200;
            i5.Height = 200;
            i5.Source = new BitmapImage(new Uri("/Resources/brosser.jpg", UriKind.Relative));
            i5.SetValue(Canvas.LeftProperty, p.X - 280);
            i5.SetValue(Canvas.TopProperty, p.Y - 130);
            canvas.Children.Add(i5);

            i6 = new Image();
            i6.Width = 200;
            i6.Height = 200;
            i6.Source = new BitmapImage(new Uri("/Resources/prendre_brossedent.png", UriKind.Relative));
            i6.SetValue(Canvas.LeftProperty, p.X - 110);
            i6.SetValue(Canvas.TopProperty, p.Y + 100);
            canvas.Children.Add(i6);
        }
        private void OnVisualizationAdded(object sender, TagVisualizerEventArgs e)
        {
            Point p=e.TagVisualization.Center;

            Point t = new Point(p.X, p.Y+210);

            try
            {
                switch (e.TagVisualization.VisualizedTag.Value)
                {
                    case 0x01: createImageBrosse(t); borderAideBrosseDent.BorderBrush = Brushes.Green; borderAideBrosseDent2.BorderBrush = Brushes.Green; brosseadentBool = true; valideObjet(); break;
                    case 0x20: createImageDentifrice(t); borderDentifrice.BorderBrush = Brushes.Green; borderDentifrice2.BorderBrush = Brushes.Green; borderDentifrice.Visibility = Visibility.Visible; dentifriceBool = true; valideObjet(); break;
                    case 0xC5: createImageVerre(t); borderVerre.BorderBrush = Brushes.Green; borderVerre2.BorderBrush = Brushes.Green; borderVerre.Visibility = Visibility.Visible; verreBool = true; valideObjet(); break;
                    default: break;
                }
            }
            catch (System.Exception ex) { Trace.WriteLine("exeption "+ex); }
        }


       /* private void List_MouseMove(object sender, MouseEventArgs e)
        {
            if (t) { 
            Point mousePos = e.GetPosition(null);
            Point position = ActionBrosser.PointToScreen(new Point(0d, 0d));
            DoubleAnimation da = new DoubleAnimation();
            //Trace.WriteLine("PosX= " + mousePos.X + " PosY = " + mousePos.Y);
            //Trace.WriteLine("ImagePosX= " +position.X + " ImagePosY = " + position.Y);
                // Get the dragged ListViewItem
                Image img = sender as Image;
                DataObject data = new DataObject(typeof(ImageSource), img.Source);
                DragDrop.DoDragDrop(img, data, DragDropEffects.Move);
        }
        }*/

        private void DropList_Drop(object sender, DragEventArgs e)
        {
            Trace.WriteLine("test drop");
            Image img = sender as Image;
            if (img != null)
            {
                // Save the current Fill brush so that you can revert back to this value in DragLeave.
   

                // If the DataObject contains string data, extract it.
                if (e.Data.GetData(typeof(ImageSource)) != null)
                {
                    //Trace.WriteLine("Entre DROP 2");
                    ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;

                    img.Source = image;
                }
            }
        }

        private void img_GiveFeedback(object sender, System.Windows.GiveFeedbackEventArgs e)
        {

        }

       /* private void mouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            if (img != null)
            {
                Point mousePos = e.GetPosition(null);
                Point position = ActionBrosser.PointToScreen(new Point(0d, 0d));
                DoubleAnimation da = new DoubleAnimation();
                //Trace.WriteLine("PosX= " + mousePos.X + " PosY = " + mousePos.Y);
                //Trace.WriteLine("ImagePosX= " + position.X + " ImagePosY = " + position.Y);
                t = true;
            }
        }*/

        private void mouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }
        void Window1_Closing(object sender, CancelEventArgs e)
        {

            Application.Current.Shutdown();

        }

        private void touch(object sender, TouchEventArgs e)
        {
            myGrid.Visibility = Visibility.Hidden;
            maison.Visibility = Visibility.Visible;

            animeMaison();
        }

        private async void brosseadent_Touch(object sender, TouchEventArgs e)
        {
            brossezdent.Stop();
            rasez.Stop();
            coiffez.Stop();
            douchez.Stop();
            brossezdent = null;
            rasez = null;
            coiffez = null;
            douchez = null;

            atelier.Visibility = Visibility.Hidden;
            objet.Visibility = Visibility.Visible;

            //Objet en Texte
            await Task.Delay(3000);
            brosseDent.Source = new BitmapImage(new Uri("/Resources/brosseadents.png", UriKind.Relative));
            dentifrice.Source = new BitmapImage(new Uri("/Resources/dentifrice.png", UriKind.Relative));
            verre.Source = new BitmapImage(new Uri("/Resources/verre.png", UriKind.Relative));
            brosseDent2.Source = new BitmapImage(new Uri("/Resources/brosseadents.png", UriKind.Relative));
            dentifrice2.Source = new BitmapImage(new Uri("/Resources/dentifrice.png", UriKind.Relative));
            verre2.Source = new BitmapImage(new Uri("/Resources/verre.png", UriKind.Relative));

            //Objet en Image
            await Task.Delay(3000);
            brosseDent.Source = new BitmapImage(new Uri("/Resources/brosse_grandT.png", UriKind.Relative));
            dentifrice.Source = new BitmapImage(new Uri("/Resources/dentifrice_grand.png", UriKind.Relative));
            verre.Source = new BitmapImage(new Uri("/Resources/verre_grand.png", UriKind.Relative));
            brosseDent2.Source = new BitmapImage(new Uri("/Resources/brosse_grandT.png", UriKind.Relative));
            dentifrice2.Source = new BitmapImage(new Uri("/Resources/dentifrice_grand.png", UriKind.Relative));
            verre2.Source = new BitmapImage(new Uri("/Resources/verre_grand.png", UriKind.Relative));
            //Objet Son
            await Task.Delay(3000);
            try
            {
                brosseadentSon.Play();
            }
            catch (System.NullReferenceException) { }

            await Task.Delay(2000);
            try
            {
                dentifriceSon.Play();
            }
            catch (System.NullReferenceException) { }

            await Task.Delay(2000);
            try
            {
                verreSon.Play();
            }
            catch (System.NullReferenceException) { }
        }

        private void salledebain_Touch(object sender, TouchEventArgs e)
        {
            cuisine.Stop();
            salon.Stop();
            salledebain.Stop();
            cuisine = null;
            salon = null;
            salledebain = null;

            maison.Visibility = Visibility.Hidden;
            atelier.Visibility = Visibility.Visible;
            animeSalleDeBain();
        }

        private void deleteImageBrosse(Point p){
            canvas.Children.Remove(i4);
            canvas.Children.Remove(i5);
            canvas.Children.Remove(i6);

        }
        private void deleteImageDentifrice(Point p){
            canvas.Children.Remove(i3);
        }
        private void deleteImageVerre(Point p){
            canvas.Children.Remove(i);
            canvas.Children.Remove(i2);
        }
        private void OnvisualEnd(object sender, TagVisualizerEventArgs e)
        {
            Point p = e.TagVisualization.Center;
            Point t = new Point(p.X, p.Y + 210);
            try
            {
                switch (e.TagVisualization.VisualizedTag.Value)
                {
                    case 0x01: deleteImageBrosse(t); borderAideBrosseDent.BorderBrush = Brushes.Transparent; borderAideBrosseDent2.BorderBrush = Brushes.Transparent; brosseadentBool = false; break;
                    case 0x20: deleteImageDentifrice(t); borderDentifrice.BorderBrush = Brushes.Transparent; borderDentifrice2.BorderBrush = Brushes.Transparent; dentifriceBool = false; break;
                    case 0xC5: deleteImageVerre(t); borderVerre.BorderBrush = Brushes.Transparent; borderVerre2.BorderBrush = Brushes.Transparent; verreBool = false; break;
                    default: break;
                }
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("exeption " + ex);
            }
        }

        private void OnvisualMoved(object sender, TagVisualizerEventArgs e)
        {
            Point p = e.TagVisualization.Center;
            Point t = new Point(p.X, p.Y + 210);
            try
            {
                switch (e.TagVisualization.VisualizedTag.Value)
                {
                    case 0x01: moveImageBrosse(t); borderAideBrosseDent.BorderBrush = Brushes.Green; borderAideBrosseDent2.BorderBrush = Brushes.Green; break;
                    case 0x20: moveImageDentifrice(t); borderDentifrice.BorderBrush = Brushes.Green; borderDentifrice2.BorderBrush = Brushes.Green;  break;
                    case 0xC5: moveImageVerre(t); borderVerre.BorderBrush = Brushes.Green; borderVerre2.BorderBrush = Brushes.Green;  break;
                    default: break;
                }
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine("exeption " + ex);
            }
        }

        private void moveImageVerre(Point p)
        {
            i.SetValue(Canvas.LeftProperty, p.X - 110);
            i.SetValue(Canvas.TopProperty, p.Y - 230);
            i2.SetValue(Canvas.LeftProperty, p.X - 110);
            i2.SetValue(Canvas.TopProperty, p.Y + 30);
        }

        private void moveImageDentifrice(Point p)
        {
            i3.SetValue(Canvas.LeftProperty, p.X - 110);
            i3.SetValue(Canvas.TopProperty, p.Y - 230);
        }

        private void moveImageBrosse(Point p)
        {
            i4.SetValue(Canvas.LeftProperty, p.X + 110);
            i4.SetValue(Canvas.TopProperty, p.Y - 130);

            i5.SetValue(Canvas.LeftProperty, p.X - 280);
            i5.SetValue(Canvas.TopProperty, p.Y - 130);
            i6.SetValue(Canvas.LeftProperty, p.X - 110);
            i6.SetValue(Canvas.TopProperty, p.Y + 100);
        }

       
        private void touchTEST(object sender, TouchEventArgs e)
        {
            Trace.WriteLine("touh up frise");
            Image img = sender as Image;
            img.Source = new BitmapImage(new Uri("/Resources/mettre_dentifrice.png", UriKind.Relative));
        }
    }
}

