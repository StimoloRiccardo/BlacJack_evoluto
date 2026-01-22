using System;
using System.Windows;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace prova
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
           
            viewport.IsManipulationEnabled = false;
            viewport.IsRotationEnabled = false;
            viewport.IsZoomEnabled = true;
            viewport.IsPanEnabled = false;


            // 2. Impostiamo la camera
            viewport.Camera = new PerspectiveCamera
            {
                Position = new Point3D(0, 0, 10),      // davanti all’oggetto
                LookDirection = new Vector3D(0, 0, -10), // guarda verso l’origine
                UpDirection = new Vector3D(0, 1, 0),
                FieldOfView = 45
            };



            // 3. Luci
            viewport.Children.Add(new DefaultLights());

            // 4. Importiamo il modello OBJ
            var importer = new ModelImporter();

            try
            {
                // ⚠️ METTI QUI IL PERCORSO DEL TUO FILE OBJ
                Model3D modello = importer.Load("modelli/asso/R01-C.obj");

                var visual = new ModelVisual3D
                {
                    Content = modello
                };
                visual.Transform = new ScaleTransform3D(0.1, 0.1, 0.1);

                // 5. Scala il modello se necessario
                visual.Transform = new ScaleTransform3D(1, 1, 1);

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
