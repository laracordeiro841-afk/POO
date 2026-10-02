namespace POO.Testes;

[TestClass]
[DoNotParallelize]
public sealed class AnimalTestes
{
    private StringWriter _consoleOutput; 
    private TextWriter _originalOutput;
    
    [TestInitialize]
    public void Setup()
    {
        _consoleOutput = new StringWriter();
        _originalOutput = Console.Out;
        Console.SetOut(_consoleOutput);
    }

    [TestCleanup]
    public void Cleanup()
    {
        Console.SetOut(_originalOutput);
        _consoleOutput.Dispose();
    }

    [TestMethod]
    public void DeveRetornar_AoInstanciarCachorro_QuandoNomeEIdadeEstaoCorretos()
    {
        // arrange - Arranjo
        string nomeEsperado = "Thor";
        int idadeEsperada = 6;
        
        // Act - Ação
        var animal = new Cachorro(nomeEsperado, idadeEsperada);
        
        
        //Assert
        Assert.AreEqual(nomeEsperado, animal.Nome);
        Assert.AreEqual(idadeEsperada, animal.Idade);
    }

    [TestMethod]
    public void QuandoInvocadoComer_DeveEscreverMensagemPadraoNoConsole()
    {
        // Valor Atual: _consoleOutput.ToString()
        //Arrange
        string nome = "Milkmoo";
        var animal = new Vaca(nome, 1);
        string mensagemEsperada = $"{nome} está comendo!{Environment.NewLine}";
       
        // Act
        animal.Comer();
        //Assert - Afirmação
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
        
        
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaCachorro_DeveFazerAuAu()
    {
        //Arrange
        string nome = "Thor";
        var animal = new Cachorro(nome, 6);
        string mensagemEsperada = $"{nome} fez Auau!{Environment.NewLine}";
        // Act
       animal.FazerBarulho();
       //Assert
      
       Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
           
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaVaca_DeveFazerMuu()
    {
        string nome = "Milkmoo";
        var animal = new Vaca(nome, 1);
        string mensagemEsperada = $"{nome} faz Muuuuuuuu!{Environment.NewLine}";
        
        animal.FazerBarulho();
         
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
        
    }

    [TestMethod]
    public void QuandoInvocaFazerBarulho_DaInstanciaGato_DeveFazerMiau()  
    {
        string nome = "Beloti";
        var animal = new Gato(nome, 4);
        string mensagemEsperada = $"{nome} fez Miaaaaaaauuuuu!{Environment.NewLine}";
        
        animal.FazerBarulho();
        
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    }

    [TestMethod]
    public void QuandoInstanciarComNomeVazio_Sempre_DeveLancarArgumentException()
    {
        string nomeAnimal = string.Empty;
        
        var exececao = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 6));
        Assert.Contains("O nome não pode estar vazio ou nulo!", exececao.Message);
    }

    [TestMethod]
    public void QuandoInstanciarComNomeNulo_Sempre_DeveLancarArgumentException()
    {
        // Arrange
        string nomeAnimal = null;
        //Act -> Assert
        var exececao = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 6));
        Assert.Contains("O nome não pode estar vazio ou nulo!", exececao.Message);
    }

    [TestMethod]
    public void QuandoInstanciarComIdadeNegativa_Sempre_DeveLancarArgumentOutOfRangeException()
    {
        string nomeAnimal = "Thor";
        int idade = -6;
        
        var exececao = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new Cachorro("Thor", idade));
        Assert.Contains("A idade não pode ser negativa!", exececao.Message);     
    }
}
