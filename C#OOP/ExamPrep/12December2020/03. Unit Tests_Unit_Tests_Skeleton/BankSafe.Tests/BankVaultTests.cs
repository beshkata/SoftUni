using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        BankVault bankVault;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        [TestCase ("A1")]
        [TestCase ("B1")]
        [TestCase ("C3")]
        public void Ctor_SetsCollection(string key)
        {
            BankVault bankVault = new BankVault();

            Dictionary<string, Item> keyValuePairs = bankVault.VaultCells.ToDictionary(k => k.Key, v => v.Value);

            Assert.That(keyValuePairs.ContainsKey(key), Is.True);
        }

        [Test]
        [TestCase ("T6")]
        [TestCase ("N4")]
        public void AddItem_ThrowsWhenKeyDoesNotExist(string cell)
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem(cell, new Item("Pesho", "22")));
        }

        [Test]
        public void AddItem_ThrowsWhenItemIsNotNull()
        {
            bankVault.AddItem("A1", new Item("Pesho", "22"));
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", new Item("Ivan", "33")));
        }

        [Test]
        public void AddItem_ThrowsWhenItemAlredyExist()
        {
            string itemID = "22";
            bankVault.AddItem("A1", new Item("Pesho", itemID));
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("B1", new Item("Ivan", itemID)));
        }

        [Test]
        public void AddItem_ReturnsRightStringWhenAddsSuccessfully()
        {
            string itemID = "22";
            Assert.That(bankVault.AddItem("A1", new Item("Pesho", itemID)),
                Is.EqualTo($"Item:{itemID} saved successfully!"));
        }

        [Test]
        [TestCase("T6")]
        [TestCase("N4")]
        public void RemoveItem_ThrowsWhenKeyDoesNotExist(string cell)
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem(cell, new Item("Pesho", "22")));
        }

        [Test]
        public void RemoveItem_ThrowsWhenItemDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", new Item("Pesho", "22")));
        }

        [Test]
        public void RemoveItem_RemovesItem()
        {
            string cell = "A1";
            Item item = new Item("Pesho", "22");
            bankVault.AddItem(cell, item);
            bankVault.RemoveItem(cell, item);

            Assert.IsNull(bankVault.VaultCells[cell]);
        }

        [Test]
        public void RemoveItem_ReturnsRightStringWhenRemovesSuccessfully()
        {
            string cell = "A1";
            Item item = new Item("Pesho", "22");
            bankVault.AddItem(cell, item);

            Assert.That(bankVault.RemoveItem(cell, item), Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }

    }
}