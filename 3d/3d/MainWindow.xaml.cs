using System;
using System.Windows;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace _3d
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Create3DViewPort();
        }

        private void Create3DViewPort()
        {

            // 1. Creiamo la viewport
            var viewport = new HelixViewport3D();

            //viewport.IsManipulationEnabled = false;
            //viewport.IsRotationEnabled = false;
            //viewport.IsZoomEnabled = true;
            //viewport.IsPanEnabled = false;


            // 2. Impostiamo la camera
            viewport.Camera = new PerspectiveCamera
            {
                Position = new Point3D(400,160, 560),        // in alto
                LookDirection = new Vector3D(30, 1, -400), // guarda verso il basso
                UpDirection = new Vector3D(1, 0, 0),    // orientamento corretto
                FieldOfView = 50
            };




            // 3. Luci
            viewport.Children.Add(new DefaultLights());

            // 4. Importiamo il modello OBJ
            var importer = new ModelImporter();

            try
            {
                // 1) Carichi il modello OBJ
                Model3D modello = importer.Load("3d/tavolo/blackjack_table.obj");

                // 2) QUI inserisci la trasformazione per correggere le facce ribaltate
                modello.Transform = new ScaleTransform3D(1.8,1.8,-1.8);
                // oppure modello.Transform = new ScaleTransform3D(-1, 1, 1);

                // 3) Crei il visual
                var visual = new ModelVisual3D
                {
                    Content = modello
                };

                // 4) Aggiungi alla viewport
                viewport.Children.Add(visual);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore nel caricamento del modello: " + ex.Message);
            }


            // 6. Aggiungiamo la viewport al Grid del XAML
            RootGrid.Children.Add(viewport);
        }
    }
}
