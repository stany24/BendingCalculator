using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Flexion;

namespace FlexionTests
{
    [TestClass]
    public class AdditionalMathTests
    {
        AdditionalMath math = new AdditionalMath();

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
            Piece piece = new Piece(1.5, "test",69e9);
            Assert.IsInstanceOfType(piece, typeof(Piece));
            Assert.IsNotNull(piece);
        }

        [TestMethod]
        public void TestGetter()
        {
            Piece piece = new Piece(1.5, "test",69e9);
            Assert.AreEqual(piece.GetLongueur(),1.5);
            Assert.AreEqual(piece.GetNom(),"test");
            Assert.AreEqual(piece.GetEref(),69e9);
        }

        [TestMethod]
        public void TestSetter()
        {
            Piece piece = new Piece(1.5, "test", 69e9);
            piece.SetLongueur(3.5);
            piece.SetNom("new");
            piece.SetEref(54e6);
            Assert.AreEqual(piece.GetLongueur(), 3.5);
            Assert.AreEqual(piece.GetNom(), "new");
            Assert.AreEqual(piece.GetEref(), 54e6);
        }
    }
}
