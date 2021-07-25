using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
namespace TestUnitarios
{
    /// <summary>
    /// Verifica que las dos producciones tienen el mismo numero de serie
    /// </summary>
    [TestClass]
    public class TestFabrica
    {
        [TestMethod]
        public void VerificarProduccionRepetida_Ok()
        {
            Clasico anteojo1 = new Clasico(false, 1, 1, EArmazon.Acero, ELente.Plastico, EColor.Blanco, true, true);
            Clasico anteojo2 = new Clasico(false, 1, 1, EArmazon.Acero, ELente.Plastico, EColor.Blanco, true, true);

            bool retorno = anteojo1 == anteojo2;

            Assert.IsTrue(retorno);
        }

        /// <summary>
        /// Verifica que se lanze la excepcion
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ProduccionRepetidaException))]
        public void AgregarProduccionRepetida()
        {
            DepositoFabrica<Anteojo> deposito = new DepositoFabrica<Anteojo>("Test Fabrica");
            Clasico anteojo1 = new Clasico(false, 1, 1, EArmazon.Acero, ELente.Plastico, EColor.Blanco, true, true);
            Clasico anteojo2 = new Clasico(false, 1, 1, EArmazon.Acero, ELente.Plastico, EColor.Blanco, true, true);
            deposito += anteojo1;
            deposito += anteojo2;
        }


    }
}
