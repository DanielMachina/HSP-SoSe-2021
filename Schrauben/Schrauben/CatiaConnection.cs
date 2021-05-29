using System;
using System.Windows;
using HybridShapeTypeLib;
using INFITF;
using MECMOD;
using PARTITF;


namespace Schrauben
{
    class CatiaConnection
    {
        INFITF.Application hsp_catiaApp;
        MECMOD.PartDocument hsp_catiaPartDoc;
        MECMOD.Sketch hsp_catiaSkizze;
        MECMOD.Sketch hsp_catiaSkizze2;
        HybridBody catHybridBody1;

        ShapeFactory SF;
        HybridShapeFactory HSF;
        Pad KopfPad;
        Pad mySchaft;
        Body myBody;
        Part myPart;
        Sketches mySketches;
        Pocket ISechs;
        //EdgeFillet RadiusKopf;

        #region MinimalCatia
        public bool CATIALaeuft()
        {
            try
            {
                object catiaObject = System.Runtime.InteropServices.Marshal.GetActiveObject(
                    "CATIA.Application");
                hsp_catiaApp = (INFITF.Application)catiaObject;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean ErzeugePart()
        {
            INFITF.Documents catDocuments1 = hsp_catiaApp.Documents;
            hsp_catiaPartDoc = catDocuments1.Add("Part") as MECMOD.PartDocument;

            return true;
        }

        public void ErstelleLeereSkizze()
        {
            // geometrisches Set auswaehlen und umbenennen
            SF = (ShapeFactory)hsp_catiaPartDoc.Part.ShapeFactory;
            HybridBodies catHybridBodies1 = hsp_catiaPartDoc.Part.HybridBodies;
            try
            {
                catHybridBody1 = catHybridBodies1.Item("Geometrisches Set.1");
            }
            catch (Exception)
            {
                MessageBox.Show("Kein geometrisches Set gefunden! " + Environment.NewLine +
                    "Ein PART manuell erzeugen und ein darauf achten, dass 'Geometisches Set' aktiviert ist.",
                    "Fehler", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            catHybridBody1.set_Name("Profile");
            // neue Skizze im ausgewaehlten geometrischen Set anlegen
            mySketches = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPartDoc.Part.OriginElements;
            Reference catReference1 = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaSkizze = mySketches.Add(catReference1);

            // Achsensystem in Skizze erstellen 
            ErzeugeAchsensystem();

            // Part aktualisieren
            hsp_catiaPartDoc.Part.Update();
        }

        private void ErzeugeAchsensystem()
        {
            object[] arr = new object[] {0.0, 0.0, 0.0,
                                         0.0, 1.0, 0.0,
                                         0.0, 0.0, 1.0 };
            hsp_catiaSkizze.SetAbsoluteAxisData(arr);
        }

        public void ErzeugeProfil(Double b, Double h)
        {
            // Skizze umbenennen
            hsp_catiaSkizze.set_Name("Rechteck");

            // Rechteck in Skizze einzeichnen
            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaSkizze.OpenEdition();

            // Rechteck erzeugen

            // erst die Punkte
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(-50, 50);
            Point2D catPoint2D2 = catFactory2D1.CreatePoint(50, 50);
            Point2D catPoint2D3 = catFactory2D1.CreatePoint(50, -50);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(-50, -50);

            // dann die Linien
            Line2D catLine2D1 = catFactory2D1.CreateLine(-50, 50, 50, 50);
            catLine2D1.StartPoint = catPoint2D1;
            catLine2D1.EndPoint = catPoint2D2;

            Line2D catLine2D2 = catFactory2D1.CreateLine(50, 50, 50, -50);
            catLine2D2.StartPoint = catPoint2D2;
            catLine2D2.EndPoint = catPoint2D3;

            Line2D catLine2D3 = catFactory2D1.CreateLine(50, -50, -50, -50);
            catLine2D3.StartPoint = catPoint2D3;
            catLine2D3.EndPoint = catPoint2D4;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-50, -50, -50, 50);
            catLine2D4.StartPoint = catPoint2D4;
            catLine2D4.EndPoint = catPoint2D1;

            // Skizzierer verlassen
            hsp_catiaSkizze.CloseEdition();
            // Part aktualisieren
            hsp_catiaPartDoc.Part.Update();
        }

        public void ErzeugeBalken(Double l)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPartDoc.Part.InWorkObject = hsp_catiaPartDoc.Part.MainBody;

            // Block(Balken) erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPartDoc.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaSkizze, l);

            // Block umbenennen
            catPad1.set_Name("Balken");

            // Part aktualisieren
            hsp_catiaPartDoc.Part.Update();
        }
        #endregion

        #region Schraube
        internal void ErzeugeSchaft(Schraube mySchraube)
        {
            myPart = hsp_catiaPartDoc.Part;
            Bodies bodies = myPart.Bodies;
            myBody = myPart.MainBody;
            // myBody = bodies.Add();

            // Hauptkoerper in Bearbeitung definieren
            myPart.InWorkObject = myPart.MainBody;

            // Skizze umbenennen
            hsp_catiaSkizze.set_Name("Kreis");

            // Skizze...
            // ... oeffnen für die Bearbeitung
            Factory2D catFactory2D1 = hsp_catiaSkizze.OpenEdition();

            // ... Kreis erstellen
            double H0 = 0;
            double V0 = 0;
            Point2D Ursprung = catFactory2D1.CreatePoint(H0, V0);
            Circle2D Kreis = catFactory2D1.CreateCircle(H0, V0, mySchraube.Ri, 0, 0);
            Kreis.CenterPoint = Ursprung;

            // ... schliessen
            hsp_catiaSkizze.CloseEdition();

            // Schraubenschaft durch ein Pad erstellen
            Reference RefMySchaft = myPart.CreateReferenceFromObject(hsp_catiaSkizze);
            mySchaft = SF.AddNewPadFromRef(RefMySchaft, mySchraube.laenge);
            myPart.Update();

        }

        // Erzeugt ein Gewindefeature auf dem vorher erzeugten Schaft.
        internal void ErzeugeGewindeFeature()
        {
            // Gewinde...
            // ... Referenzen lateral und limit erzeugen
            Reference RefMantelflaeche = myPart.CreateReferenceFromBRepName(
                "RSur:(Face:(Brp:(Pad.1;0:(Brp:(Sketch.1;1)));None:();Cf11:());WithTemporaryBody;WithoutBuildError;WithSelectingFeatureSupport;MFBRepVersion_CXR15)", mySchaft);
            Reference RefFrontflaeche = myPart.CreateReferenceFromBRepName(
                "RSur:(Face:(Brp:(Pad.1;2);None:();Cf11:());WithTemporaryBody;WithoutBuildError;WithSelectingFeatureSupport;MFBRepVersion_CXR15)", mySchaft);

            // ... Gewinde erzeugen, Parameter setzen
            PARTITF.Thread thread1 = SF.AddNewThreadWithOutRef();
            thread1.Side = CatThreadSide.catRightSide;
            thread1.Diameter = 8.000000;
            thread1.Depth = 50.000000;
            thread1.LateralFaceElement = RefMantelflaeche; // Referenz lateral
            thread1.LimitFaceElement = RefFrontflaeche; // Referenz limit

            // ... Standardgewinde gesteuert über eine Konstruktionstabelle
            thread1.CreateUserStandardDesignTable("Metric_Thick_Pitch", @"C:\Program Files\Dassault Systemes\B28\win_b64\resources\standard\thread\Metric_Thick_Pitch.xml");
            thread1.Diameter = 8.000000;
            thread1.Pitch = 1.250000;

            // Part update und fertig
            myPart.Update();
        }

        // Erzeugt eine Helix 
        internal void ErzeugeGewindeHelix(Schraube mySchraube)
        {
            Double P = mySchraube.P;
            Double Ri = mySchraube.Ri;
            HSF = (HybridShapeFactory)myPart.HybridShapeFactory;

            Sketch myGewinde = makeGewindeSkizze(mySchraube);

            HybridShapeDirection HelixDir = HSF.AddNewDirectionByCoord(1, 0, 0);
            Reference RefHelixDir = myPart.CreateReferenceFromObject(HelixDir);

            HybridShapePointCoord HelixStartpunkt = HSF.AddNewPointCoord(0, 0, Ri);
            Reference RefHelixStartpunkt = myPart.CreateReferenceFromObject(HelixStartpunkt);

            HybridShapeHelix Helix = HSF.AddNewHelix(RefHelixDir, false, RefHelixStartpunkt, P, mySchraube.gewindeLaenge, false, 0, 0, false);

            Reference RefHelix = myPart.CreateReferenceFromObject(Helix);
            Reference RefmyGewinde = myPart.CreateReferenceFromObject(myGewinde);

            myPart.Update();

            myPart.InWorkObject = myBody;

            OriginElements catOriginElements = this.hsp_catiaPartDoc.Part.OriginElements;
            Reference RefmyPlaneZX = (Reference)catOriginElements.PlaneZX;

            Sketch ChamferSkizze = mySketches.Add(RefmyPlaneZX);
            myPart.InWorkObject = ChamferSkizze;
            ChamferSkizze.set_Name("Fase");

            double H_links = Ri;
            double V_links = 0.65 * P;

            double H_rechts = Ri;
            double V_rechts = 0;

            double H_unten = Ri - 0.65 * P;
            double V_unten = 0;

            Factory2D catFactory2D3 = ChamferSkizze.OpenEdition();

            Point2D links = catFactory2D3.CreatePoint(H_links, V_links);
            Point2D rechts = catFactory2D3.CreatePoint(H_rechts, V_rechts);
            Point2D unten = catFactory2D3.CreatePoint(H_unten, V_unten);

            Line2D Oben = catFactory2D3.CreateLine(H_links, V_links, H_rechts, V_rechts);
            Oben.StartPoint = links;
            Oben.EndPoint = rechts;

            Line2D hypo = catFactory2D3.CreateLine(H_links, V_links, H_unten, V_unten);
            hypo.StartPoint = links;
            hypo.EndPoint = unten;

            Line2D seite = catFactory2D3.CreateLine(H_unten, V_unten, H_rechts, V_rechts);
            seite.StartPoint = unten;
            seite.EndPoint = rechts;

            ChamferSkizze.CloseEdition();

            myPart.InWorkObject = myBody;
            myPart.Update();

            Groove myChamfer = SF.AddNewGroove(ChamferSkizze);
            myChamfer.RevoluteAxis = RefHelixDir;

            myPart.Update();

            Slot GewindeRille = SF.AddNewSlotFromRef(RefmyGewinde, RefHelix);

            Reference RefmyPad = myPart.CreateReferenceFromObject(mySchaft);
            HybridShapeSurfaceExplicit GewindestangenSurface = HSF.AddNewSurfaceDatum(RefmyPad);
            Reference RefGewindestangenSurface = myPart.CreateReferenceFromObject(GewindestangenSurface);

            GewindeRille.ReferenceSurfaceElement = RefGewindestangenSurface;

            Reference RefGewindeRille = myPart.CreateReferenceFromObject(GewindeRille);

            myPart.Update();
        }

        // Separate Skizzenerzeugung für de Helix
        private Sketch makeGewindeSkizze(Schraube dieSchraube)
        {
            Double P = dieSchraube.P;
            Double Ri = dieSchraube.Ri;

            OriginElements catOriginElements = hsp_catiaPartDoc.Part.OriginElements;
            Reference RefmyPlaneZX = (Reference)catOriginElements.PlaneZX;

            Sketch myGewinde = mySketches.Add(RefmyPlaneZX);
            myPart.InWorkObject = myGewinde;
            myGewinde.set_Name("Gewinde");

            double V_oben_links = -(((((Math.Sqrt(3) / 2) * P) / 6) + 0.6134 * P) * Math.Tan((30 * Math.PI) / 180));
            double H_oben_links = Ri;

            double V_oben_rechts = (((((Math.Sqrt(3) / 2) * P) / 6) + 0.6134 * P) * Math.Tan((30 * Math.PI) / 180));
            double H_oben_rechts = Ri;

            double V_unten_links = -((0.1443 * P) * Math.Sin((60 * Math.PI) / 180));
            double H_unten_links = Ri - (0.6134 * P - 0.1443 * P) - Math.Sqrt(Math.Pow((0.1443 * P), 2) - Math.Pow((0.1443 * P) * Math.Sin((60 * Math.PI) / 180), 2));

            double V_unten_rechts = (0.1443 * P) * Math.Sin((60 * Math.PI) / 180);
            double H_unten_rechts = Ri - (0.6134 * P - 0.1443 * P) - Math.Sqrt(Math.Pow((0.1443 * P), 2) - Math.Pow((0.1443 * P) * Math.Sin((60 * Math.PI) / 180), 2));

            double V_Mittelpunkt = 0;
            double H_Mittelpunkt = Ri - ((0.6134 * P) - 0.1443 * P);

            Factory2D catFactory2D2 = myGewinde.OpenEdition();

            Point2D Oben_links = catFactory2D2.CreatePoint(H_oben_links, V_oben_links);
            Point2D Oben_rechts = catFactory2D2.CreatePoint(H_oben_rechts, V_oben_rechts);
            Point2D Unten_links = catFactory2D2.CreatePoint(H_unten_links, V_unten_links);
            Point2D Unten_rechts = catFactory2D2.CreatePoint(H_unten_rechts, V_unten_rechts);
            Point2D Mittelpunkt = catFactory2D2.CreatePoint(H_Mittelpunkt, V_Mittelpunkt);

            Line2D Oben = catFactory2D2.CreateLine(H_oben_links, V_oben_links, H_oben_rechts, V_oben_rechts);
            Oben.StartPoint = Oben_links;
            Oben.EndPoint = Oben_rechts;

            Line2D Rechts = catFactory2D2.CreateLine(H_oben_rechts, V_oben_rechts, H_unten_rechts, V_unten_rechts);
            Rechts.StartPoint = Oben_rechts;
            Rechts.EndPoint = Unten_rechts;

            Circle2D Verrundung = catFactory2D2.CreateCircle(H_Mittelpunkt, V_Mittelpunkt, 0.1443 * P, 0, 0);
            Verrundung.CenterPoint = Mittelpunkt;
            Verrundung.StartPoint = Unten_rechts;
            Verrundung.EndPoint = Unten_links;

            Line2D Links = catFactory2D2.CreateLine(H_oben_links, V_oben_links, H_unten_links, V_unten_links);
            Links.StartPoint = Unten_links;
            Links.EndPoint = Oben_links;

            myGewinde.CloseEdition();
            myPart.Update();

            return myGewinde;
        }

        public Reference ErzeugeOffset(Double Höhe)
        {
            myPart.InWorkObject = myBody;
            HSF = (HybridShapeFactory)myPart.HybridShapeFactory;
            OriginElements catOriginElements = hsp_catiaPartDoc.Part.OriginElements;
            Reference RefMyOffset = (Reference)catOriginElements.PlaneZX;

            Reference RefmyPlaneYZ = (Reference)catOriginElements.PlaneYZ;
            hsp_catiaPartDoc.Part.InWorkObject = hsp_catiaPartDoc.Part;
            HybridShapeFactory hybridShapeFactory1 = (HybridShapeFactory)hsp_catiaPartDoc.Part.HybridShapeFactory;
            HybridShapePlaneOffset OffsetEbene = hybridShapeFactory1.AddNewPlaneOffset(RefmyPlaneYZ, Höhe, false);
            OffsetEbene.set_Name("OffsetEbene");
            Reference RefOffsetEbene = hsp_catiaPartDoc.Part.CreateReferenceFromObject(OffsetEbene);
            HybridBodies hybridBodies1 = hsp_catiaPartDoc.Part.HybridBodies;
            HybridBody hybridBody1 = hybridBodies1.Item("Profile");
            hybridBody1.AppendHybridShape(OffsetEbene);

            hsp_catiaPartDoc.Part.Update();
            return RefOffsetEbene;
        }


        #endregion
        #region Sechskant-Kopf
        public void ErzeugeSechsKopfSkizze(Double SW)
        {
            
            // Sechskant in Skizze einzeichnen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPartDoc.Part.OriginElements;
            
            //Offset für Kopf
            hsp_catiaSkizze = catSketches1.Add(ErzeugeOffset(Convert.ToDouble(ExcelControl.Laenge)));

            // Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaSkizze.OpenEdition();
            hsp_catiaSkizze.set_Name("Sechskant");

            // Punkte Kopf
            double tan30 = Math.Sqrt(3) / 3;
            double cos30 = Math.Sqrt(3) / 2;
            SW = ExcelControl.SWM / 2;

            Point2D catPoint2D3 = catFactory2D1.CreatePoint(SW, tan30 * SW);
            Point2D catPoint2D4 = catFactory2D1.CreatePoint(SW, -(tan30 * SW));
            Point2D catPoint2D5 = catFactory2D1.CreatePoint(0, -(SW / cos30));
            Point2D catPoint2D6 = catFactory2D1.CreatePoint(-SW, -(tan30 * SW));
            Point2D catPoint2D7 = catFactory2D1.CreatePoint(-SW, tan30 * SW);
            Point2D catPoint2D8 = catFactory2D1.CreatePoint(0, SW / cos30);

            // dann die Linien für Kopf
            Line2D catLine2D1 = catFactory2D1.CreateLine(SW, tan30 * SW, SW, -(tan30 * SW));
            catLine2D1.StartPoint = catPoint2D3;
            catLine2D1.EndPoint = catPoint2D4;

            Line2D catLine2D2 = catFactory2D1.CreateLine(SW, -(tan30 * SW), 0, -(SW / cos30));
            catLine2D2.StartPoint = catPoint2D4;
            catLine2D2.EndPoint = catPoint2D5;

            Line2D catLine2D3 = catFactory2D1.CreateLine(0, -(SW / cos30), -SW, -(tan30 * SW));
            catLine2D3.StartPoint = catPoint2D5;
            catLine2D3.EndPoint = catPoint2D6;

            Line2D catLine2D4 = catFactory2D1.CreateLine(-SW, -(tan30 * SW), -SW, tan30 * SW);
            catLine2D4.StartPoint = catPoint2D6;
            catLine2D4.EndPoint = catPoint2D7;

            Line2D catLine2D5 = catFactory2D1.CreateLine(-SW, tan30 * SW, 0, SW / cos30);
            catLine2D5.StartPoint = catPoint2D7;
            catLine2D5.EndPoint = catPoint2D8;

            Line2D catLine2D6 = catFactory2D1.CreateLine(0, SW / cos30, SW, tan30 * SW);
            catLine2D6.StartPoint = catPoint2D8;
            catLine2D6.EndPoint = catPoint2D3;

            // Skizzierer verlassen
            hsp_catiaSkizze.CloseEdition();
            // Part aktualisieren
            hsp_catiaPartDoc.Part.Update();
        }

        public void ErzeugeSechskopf(Double l)
        {
            // Hauptkoerper in Bearbeitung definieren
            hsp_catiaPartDoc.Part.InWorkObject = hsp_catiaPartDoc.Part.MainBody;

            // Kopf als Körper 
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPartDoc.Part.ShapeFactory;
            Pad catPad1 = catShapeFactory1.AddNewPad(hsp_catiaSkizze, l);

            // Block umbenennen
            catPad1.set_Name("Sechskantkopf");

            // Part aktualisieren
            hsp_catiaPartDoc.Part.Update();


        }

        #endregion
        #region Zylinderkopf
        internal void Zylinderkopf()
        {

            //Skizze

            //Zyl in Skizze einzeichnen
            Sketches catSketches1 = catHybridBody1.HybridSketches;
            OriginElements catOriginElements = hsp_catiaPartDoc.Part.OriginElements;

            //Offset für Kopf
            hsp_catiaSkizze = catSketches1.Add(ErzeugeOffset(Convert.ToDouble(ExcelControl.Laenge)));

            //Skizze oeffnen
            Factory2D catFactory2D1 = hsp_catiaSkizze.OpenEdition();
            hsp_catiaSkizze.set_Name("ZylinderkopfSkizze");
            
            //Mittelpunkt
            Point2D catPoint2D1 = catFactory2D1.CreatePoint(0, 0);

            //Kreis
            Circle2D catCircle2D_1 = catFactory2D1.CreateCircle(0, 0, ExcelControl.Zyldurch /2, 0, 0);
            catCircle2D_1.CenterPoint = catPoint2D1;

            //Skizze verlassen
            hsp_catiaSkizze.CloseEdition();

            //Part aktualisieren
            hsp_catiaPartDoc.Part.Update();
        

            //Block
        
            //Hauptkoerper in Bearbeitung definieren
            hsp_catiaPartDoc.Part.InWorkObject = hsp_catiaPartDoc.Part.MainBody;

            //Block erzeugen
            ShapeFactory catShapeFactory1 = (ShapeFactory)hsp_catiaPartDoc.Part.ShapeFactory;
            KopfPad = catShapeFactory1.AddNewPad(hsp_catiaSkizze, ExcelControl.Kopfhöhe);

            //Block umbenennen
            KopfPad.set_Name("Zylinderkopf");

            //Part aktualisieren
            hsp_catiaPartDoc.Part.Update();


            //Skizze Innensechs

            //Sechskant in Skizze einzeichnen
            Sketches catSketches2 = catHybridBody1.HybridSketches;

            //Offset für Sechskant
            hsp_catiaSkizze2 = catSketches2.Add(ErzeugeOffset(Convert.ToDouble(ExcelControl.Laenge)+ExcelControl.Kopfhöhe));

            //Skizze oeffnen
            Factory2D catFactory3D2 = hsp_catiaSkizze2.OpenEdition();
            hsp_catiaSkizze2.set_Name("Innensechskantskizze");

            //Sechskant erzeugen
            double tan30 = Math.Sqrt(3) / 3;
            double cos30 = Math.Sqrt(3) / 2;
            double SW = ExcelControl.SWM / 2;

            //erst Punkte
            Point2D catPoint3D2 = catFactory3D2.CreatePoint(SW, tan30 * SW);
            Point2D catPoint3D3 = catFactory3D2.CreatePoint(SW, -(tan30 * SW));
            Point2D catPoint3D4 = catFactory3D2.CreatePoint(0, -(SW / cos30));
            Point2D catPoint3D5 = catFactory3D2.CreatePoint(-SW, -(tan30 * SW));
            Point2D catPoint3D6 = catFactory3D2.CreatePoint(-SW, tan30 * SW);
            Point2D catPoint3D7 = catFactory3D2.CreatePoint(0, SW / cos30);

            //dann Linien
            Line2D catLine2D1 = catFactory3D2.CreateLine(SW, tan30 * SW, SW, -(tan30 * SW));
            catLine2D1.StartPoint = catPoint3D2;
            catLine2D1.EndPoint = catPoint3D3;

            Line2D catLine2D2 = catFactory3D2.CreateLine(SW, -(tan30 * SW), 0, -(SW / cos30));
            catLine2D2.StartPoint = catPoint3D3;
            catLine2D2.EndPoint = catPoint3D4;

            Line2D catLine2D3 = catFactory3D2.CreateLine(0, -(SW / cos30), -SW, -(tan30 * SW));
            catLine2D3.StartPoint = catPoint3D4;
            catLine2D3.EndPoint = catPoint3D5;

            Line2D catLine2D4 = catFactory3D2.CreateLine(-SW, -(tan30 * SW), -SW, (tan30 * SW));
            catLine2D4.StartPoint = catPoint3D5;
            catLine2D4.EndPoint = catPoint3D6;

            Line2D catLine2D5 = catFactory3D2.CreateLine(-SW, (tan30 * SW), 0, SW / cos30);
            catLine2D5.StartPoint = catPoint3D6;
            catLine2D5.EndPoint = catPoint3D7;

            Line2D catLine2D6 = catFactory3D2.CreateLine(0, SW / cos30, SW, tan30 * SW);
            catLine2D6.StartPoint = catPoint3D7;
            catLine2D6.EndPoint = catPoint3D2;

            //Skizze verlassen
            hsp_catiaSkizze2.CloseEdition();

            // Part aktualisieren
            hsp_catiaPartDoc.Part.Update();

        
            //Innensechs als Tasche

            //Hauptkoerper in Bearbeitung definieren
            hsp_catiaPartDoc.Part.InWorkObject = hsp_catiaPartDoc.Part.MainBody;

            //Tasche erzeugen erzeugen
            ShapeFactory catShapeFactory2 = (ShapeFactory)hsp_catiaPartDoc.Part.ShapeFactory;

            Double t = ExcelControl.Kopfhöhe * 0.6666666666666666;
            ISechs = catShapeFactory2.AddNewPocket(hsp_catiaSkizze2, t);

            //Block umbenennen
            ISechs.set_Name("Innensechskant");

            //Part aktualisieren
            hsp_catiaPartDoc.Part.Update();
            
            
            
        }
        #endregion
        #region Senkkopf
        internal void Senkkopf()
        {

        }
        #endregion

    }
}