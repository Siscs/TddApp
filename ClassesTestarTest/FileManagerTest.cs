using System;
using ClassesTestar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassesTestarTest
{
    [TestClass]
    public class FileManagerTest
    {
        public TestContext TestContext { get; set; }

        #region Test initialize e clean up

        [TestInitialize]
        public void Initialize()
        {
            // exec antes dos testes / teste selecionado

            if (TestContext.TestName == "ArquivoExiste")
            {
                TestContext.WriteLine("Initialize...");
            }
        }

        [TestCleanup]
        public void CleanUp() // exec apos os teste / teste selecinado
        {

            if (TestContext.TestName == "ArquivoExiste")
            {
                TestContext.WriteLine("Clean up...");
            }
        }


        #endregion


        [TestMethod]
        [Description("Testa de arquivo existe")]
        [Owner("CesarS")]
        public void ArquivoExiste()
        {
            TestContext.WriteLine("Testando se arquivo existe...");

            FileManager fm = new FileManager();
            bool retorno = fm.ExisteArquivo(@"c:\windows\regedit.exe");
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        [Description("Testa de arquivo não existe")]
        [Owner("RyanS")]
        public void ArquivoNaoExiste()
        {
            TestContext.WriteLine("Testando se arquivo não existe...");
            FileManager fm = new FileManager();
            bool retorno = fm.ExisteArquivo(@"c:\windows\regedit2.exe");
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        [Description("Teste de expetion")]
        [Owner("TitiS")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Arquivo_Throw_ArgumentException()
        {
            TestContext.WriteLine("Testando argument exception...");

            FileManager fm = new FileManager();
            fm.ExisteArquivo("");
        }

        [TestMethod]
        [Description("Teste de expetion com try catch")]
        [Owner("RyanS")]
        // [Ignore]
        public void Arquivo_Throw_ArgumentException_TryCatch()
        {
            TestContext.WriteLine("Testando com try catch...");

            FileManager fm = new FileManager();

            try
            {
                // fm.ExisteArquivo(@"c:\teste.ddd");
                fm.ExisteArquivo("");
            }
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail("Teste Falhou não gerou exception");
        }

        [TestMethod]
        [Description("Teste de expetion com try catch")]
        [Owner("TitiS")]
        [Timeout(3100)]
        public void TestarTempoExecucao()
        {
            System.Threading.Thread.Sleep(3000);
        }

    }
}
