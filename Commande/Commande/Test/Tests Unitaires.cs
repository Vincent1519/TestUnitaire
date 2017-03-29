using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GestionCommande.controleur;
using System.Linq;
using GestionCommande.dao;
using GestionCommande.model;

namespace GestionCommande.Test
{
    /// <summary>
    /// Description résumée pour Tests_Unitaires
    /// </summary>
    [TestClass]
    public class Tests_Unitaires
    {
        [TestMethod]
        public void TestCreerClient()
        {
            Controleur controleur = new CommandeControleur();
            controleur.CreerClient("Minhoto", "Theo", "Minhoto.theo@gmail.com");

            Assert.AreEqual("Minhoto", controleur.GetClients().Last().Nom);
            Assert.AreEqual("Theo", controleur.GetClients().Last().Prenom);
            Assert.AreEqual("Minhoto.theo@gmail.com", controleur.GetClients().Last().Mail);
        }

        [TestMethod]
        public void TestCreerProduit()
        {
            Controleur controleur = new CommandeControleur();
            controleur.CreerProduit("Jambe", 10);

            Assert.AreEqual("Jambe", controleur.GetProduits().Last().Designation);
            Assert.AreEqual(10 , controleur.GetProduits().Last().Prix);
        }

        [TestMethod]
        public void TestCreerCommande()
        {
            Controleur controleur = new CommandeControleur();
            Client Test = new Client();
            Test.Nom = "Minhoto";
            Test.Prenom = "Theo";
            Test.Mail = "Minhoto.theo@gmail.com";
            List<LigneCommande> Listecommand = new List<LigneCommande>();
            Listecommand.Add(new LigneCommande() { Produit=controleur.GetProduits().First(), Quantite = 2 });
            Listecommand.Add(new LigneCommande() { Produit = controleur.GetProduits().Last(), Quantite = 2 });
            controleur.CreerCommande(Test, Listecommand);

            Assert.AreEqual(Test, controleur.GetCommandes().Last().Client);
            Assert.AreEqual(Listecommand, controleur.GetCommandes().Last().LignesCommande);
        }
        }
}
