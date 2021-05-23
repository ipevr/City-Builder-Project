using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridStructureTest
{
    GridStructure gridStructure;

    [OneTimeSetUp]
    public void Init()
    {
        gridStructure = new GridStructure(3, 100, 100);
    }


    #region Grid Position Tests

    // A Test behaves as an ordinary method
    [Test]
    public void GetGridPositionVectorZeroPasses()
    {
        // Arrange
        Vector3 position = new Vector3(0, 0, 0);

        // Act
        Vector3 returnPosition = gridStructure.GetGridPosition(position);

        // Assert
        Assert.AreEqual(Vector3.zero, returnPosition);
    }

    [Test]
    public void GetGridPositionFloatsPasses()
    {
        // Arrange
        Vector3 position = new Vector3(2.9f, 0, 2.9f);

        // Act
        Vector3 returnPosition = gridStructure.GetGridPosition(position);

        // Assert
        Assert.AreEqual(Vector3.zero, returnPosition);
    }

    [Test]
    public void GetGridPositionFails()
    {
        // Arrange
        Vector3 position = new Vector3(3.1f, 0, 0);

        // Act
        Vector3 returnPosition = gridStructure.GetGridPosition(position);

        // Assert
        Assert.AreNotEqual(Vector3.zero, returnPosition);
    }

    #endregion


    #region Grid Cell Taken Tests

    [Test]
    public void PlaceStructure303AndCheckIsTakenPasses()
    {
        // Arrange
        Vector3 position = new Vector3(3, 0, 3);

        // Act
        GameObject testObject = new GameObject("TestGameObject");
        gridStructure.PlaceStructureOnGrid(testObject, position);

        // Assert
        Assert.AreEqual(true, gridStructure.IsCellTaken(position));

    }

    [Test]
    public void PlaceStructureMinAndCheckIsTakenPasses()
    {
        // Arrange
        Vector3 position = new Vector3(0, 0, 0);

        // Act
        GameObject testObject = new GameObject("TestGameObject");
        gridStructure.PlaceStructureOnGrid(testObject, position);

        // Assert
        Assert.AreEqual(true, gridStructure.IsCellTaken(position));

    }

    [Test]
    public void PlaceStructureMaxAndCheckIsTakenPasses()
    {
        // Arrange
        Vector3 position = new Vector3(299, 0, 299);

        // Act
        GameObject testObject = new GameObject("TestGameObject");
        gridStructure.PlaceStructureOnGrid(testObject, position);

        // Assert
        Assert.AreEqual(true, gridStructure.IsCellTaken(position));

    }

    [Test]
    public void PlaceStructureOverMaxAndCheckIsTakenFails()
    {
        // Arrange
        Vector3 position = new Vector3(300, 0, 300);

        // Act
        GameObject testObject = new GameObject("TestGameObject");
        gridStructure.PlaceStructureOnGrid(testObject, position);

        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => gridStructure.IsCellTaken(position));

    }

    [Test]
    public void PlaceStructureUnderMinAndCheckIsTakenFails()
    {
        // Arrange
        Vector3 position = new Vector3(-3, 0, -3);

        // Act
        GameObject testObject = new GameObject("TestGameObject");
        gridStructure.PlaceStructureOnGrid(testObject, position);

        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => gridStructure.IsCellTaken(position));

    }

    #endregion

}
