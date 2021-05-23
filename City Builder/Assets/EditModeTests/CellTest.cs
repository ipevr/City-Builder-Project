using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellTest
{
    [Test]
    public void CellSetConstructionPass()
    {
        // Arrange
        Cell cell = new Cell();

        // Act
        cell.SetConstruction(new GameObject());

        // Assert
        Assert.IsTrue(cell.IsTaken);
    }

    [Test]
    public void CellSetConstructionNullFails()
    {
        // Arrange
        Cell cell = new Cell();

        // Act
        cell.SetConstruction(null);

        // Assert
        Assert.IsFalse(cell.IsTaken);
    }
}
