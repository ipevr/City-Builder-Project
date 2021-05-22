using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GridStructureTests
{
    GridStructure gridStructure;

    [OneTimeSetUp]
    public void Init()
    {
        gridStructure = new GridStructure(3);
    }

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

}
