using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace QuadraticSolverTest
{
    [TestClass]
    public class QuadraticUnitTest
    {
        [TestMethod]
        public void Should_TwoSolve_When_GreatZero()
        {
            QuadraticSolver.QuadraticSolver.Solve(2, -3, -2, out double x1, out double x2);

            Assert.AreEqual(x1,2);
            Assert.AreEqual(x2,-0.6);
        }

        [TestMethod]
        public void Should_OneSolve_When_A_EquealZero()
        {
            QuadraticSolver.QuadraticSolver.Solve(1, 4, 4, out double x1, out double x2);

            Assert.AreEqual(x1,-2);
            Assert.AreEqual(x2,-2);
        }
    }
}
