using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Flexion;
using System.Collections.Generic;

namespace FlexionTests
{
    [TestClass]
    public class AdditionalMathTests
    {
        //AdditionalMath math = new AdditionalMath();

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }

    [TestClass]
    public class MatiereTests
    {
        [TestMethod]
        public void TestConstructeur()
        {
            Matiere matiere = new Matiere("test", 69e9);
            Assert.IsInstanceOfType(matiere, typeof(Matiere));
            Assert.IsNotNull(matiere);
        }

        [TestMethod]
        public void TestGetter()
        {
            Matiere matiere = new Matiere("test", 69e9);
            Assert.AreEqual(matiere.GetE(), 69e9);
            Assert.AreEqual(matiere.GetNom(), "test");
        }

        [TestMethod]
        public void TestSetter()
        {
            Matiere matiere = new Matiere("test", 69e9);
            matiere.SetE(54e6);
            matiere.SetNom("new");
            Assert.AreEqual(matiere.GetE(), 54e6);
            Assert.AreEqual(matiere.GetNom(), "new");
        }
    }

    [TestClass]
    public class CoucheTests
    {
        [TestMethod]
        public void TestConstructeurSimple()
        {
            Matiere matiere = new Matiere("test", 69e9);
            Couche couche = new Couche(matiere, 0.1, 0.2);
            Assert.IsInstanceOfType(couche, typeof(Couche));
            Assert.IsNotNull(couche);
        }

        [TestMethod]
        public void TestConstructeurComplexe()
        {
            Matiere matiere = new Matiere("test", 69e9);
            Couche couche = new Couche(matiere, 0.1, 0.2,0.3,0.4);
            Assert.IsInstanceOfType(couche, typeof(Couche));
            Assert.IsNotNull(couche);
        }

        [TestMethod]
        public void TestGetter()
        {
            Matiere matiere = new Matiere("test", 69e9);
            Couche couche = new Couche(matiere, 0.1, 0.2, 0.3, 0.4);
            Assert.AreEqual(couche.GetLargeurCenter(), 0.1);
            Assert.AreEqual(couche.GetLargeurSide(), 0.2);
            Assert.AreEqual(couche.GetHauteurCenter(), 0.3);
            Assert.AreEqual(couche.GetHauteurSide(), 0.4);
        }

        [TestMethod]
        public void TestSetter()
        {
            Matiere matiere = new Matiere("test", 69e9);
            Matiere newmatiere = new Matiere("newtest", 54e6);
            Couche couche = new Couche(matiere, 0.1, 0.2, 0.3, 0.4);
            couche.SetLargeurCenter(1);
            couche.SetLargeurSide(2);
            couche.SetHauteurCenter(3);
            couche.SetHauteurSide(4);
            couche.SetMatiere(newmatiere);
            Assert.AreEqual(couche.GetLargeurCenter(), 1);
            Assert.AreEqual(couche.GetLargeurSide(), 2);
            Assert.AreEqual(couche.GetHauteurCenter(), 3);
            Assert.AreEqual(couche.GetHauteurSide(), 4);
            Assert.AreEqual(couche.GetMatiere(), newmatiere);
        }
    }

    [TestClass]
    public class PieceTests
    {
        [TestMethod]
        public void TestConstructeurSimple()
        {
            Piece piece = new Piece(1.5, "test");
            Assert.IsInstanceOfType(piece, typeof(Piece));
            Assert.IsNotNull(piece);
        }

        [TestMethod]
        public void TestConstructeurComplexe()
        {
            Piece piece = new Piece(1.5, "test",69e9, 1e-4);
            Assert.IsInstanceOfType(piece, typeof(Piece));
            Assert.IsNotNull(piece);
        }

        [TestMethod]
        public void TestGetter()
        {
            Piece piece = new Piece(1.5, "test",69e9, 1e-4);
            Assert.AreEqual(piece.GetLongueur(),1.5);
            Assert.AreEqual(piece.GetNom(),"test");
            Assert.AreEqual(piece.GetEref(),69e9);
        }

        [TestMethod]
        public void TestSetter()
        {
            Piece piece = new Piece(1.5, "test", 69e9, 1e-4);
            piece.SetLongueur(3.5);
            piece.SetNom("new");
            piece.SetEref(54e6);
            Assert.AreEqual(piece.GetLongueur(), 3.5);
            Assert.AreEqual(piece.GetNom(), "new");
            Assert.AreEqual(piece.GetEref(), 54e6);
        }

        [TestMethod]
        public void TestResultat()
        {
            double[] correcte = { -0.000367149758454106, -0.000734170692431562, -0.00110093397745572, -0.00146731078904992, -0.00183317230273752, -0.00219838969404187, -0.00256283413848631, -0.0029263768115942, -0.00328888888888889, -0.00365024154589372, -0.00401030595813205, -0.00436895330112722, -0.00472605475040258, -0.00508148148148148, -0.00543510466988728, -0.00578679549114332, -0.00613642512077295, -0.00648386473429952, -0.00682898550724638, -0.00717165861513688, -0.00751175523349437, -0.00784914653784219, -0.0081837037037037, -0.00851529790660225, -0.00884380032206119, -0.00916908212560386, -0.00949101449275362, -0.00980946859903382, -0.0101243156199678, -0.0104354267310789, -0.0107426731078905, -0.0110459259259259, -0.0113450563607085, -0.0116399355877617, -0.0119304347826087, -0.0122164251207729, -0.0124977777777778, -0.0127743639291465, -0.0130460547504026, -0.0133127214170692, -0.0135742351046699, -0.0138304669887279, -0.0140812882447665, -0.0143265700483092, -0.0145661835748792, -0.0148, -0.0150278904991948, -0.0152497262479871, -0.0154653784219002, -0.0156747181964573, -0.015877616747182, -0.0160739452495974, -0.0162635748792271, -0.0164463768115942, -0.0166222222222222, -0.0167909822866345, -0.0169525281803543, -0.017106731078905, -0.01725346215781, -0.0173925925925926, -0.0175239935587762, -0.0176475362318841, -0.0177630917874396, -0.0178705314009662, -0.0179697262479871, -0.0180605475040258, -0.0181428663446055, -0.0182165539452496, -0.0182814814814815, -0.0183375201288245, -0.0183845410628019, -0.0184224154589372, -0.0184510144927536, -0.0184702093397746, -0.0184798711755233, -0.0184798711755233, -0.0184703381642512, -0.0184514009661836, -0.0184231884057971, -0.0183858293075684, -0.0183394524959742, -0.0182841867954911, -0.0182201610305958, -0.0181475040257649, -0.018066344605475, -0.0179768115942029, -0.0178790338164251, -0.0177731400966184, -0.0176592592592593, -0.0175375201288245, -0.0174080515297907, -0.0172709822866345, -0.0171264412238325, -0.0169745571658615, -0.0168154589371981, -0.0166492753623188, -0.0164761352657005, -0.0162961674718197, -0.016109500805153, -0.0159162640901771, -0.0157165861513688, -0.0155105958132045, -0.015298421900161, -0.015080193236715, -0.014856038647343, -0.0146260869565217, -0.0143904669887279, -0.014149307568438, -0.0139027375201288, -0.013650885668277, -0.0133938808373591, -0.0131318518518519, -0.0128649275362319, -0.0125932367149759, -0.0123169082125604, -0.0120360708534622, -0.0117508534621578, -0.011461384863124, -0.0111677938808374, -0.0108702093397746, -0.0105687600644122, -0.0102635748792271, -0.00995478260869566, -0.0096425120772947, -0.00932689210950081, -0.00900805152979067, -0.00868611916264091, -0.00836122383252819, -0.00803349436392916, -0.00770305958132046, -0.00737004830917876, -0.00703458937198069, -0.00669681159420291, -0.00635684380032208, -0.00601481481481483, -0.00567085346215783, -0.00532508856682771, -0.00497764895330114, -0.00462866344605477, -0.00427826086956524, -0.0039265700483092, -0.0035737198067633, -0.00321983896940421, -0.00286505636070856, -0.002509500805153, -0.00215330112721419, -0.00179658615136878, -0.00143948470209342, -0.00108212560386476, -0.000724637681159446, -0.000367149758454132};
            Piece piece = new Piece(1500e-3, "Démo",69e9,1e-2);
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 100e-3, 5e-3, 5e-3));
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 100e-3, 5e-3, 5e-3));
            piece.Couches.Add(new Couche(new Matiere("alu", 69e9), 100e-3, 100e-3, 5e-3, 5e-3));
            double[] resultat = piece.Intégrale(500,1e-4);
            for (int i = 0; i < resultat.Length; i++)
            {
                Assert.AreEqual(correcte[i], resultat[i],0.000001);
            }
        }
    }
}
