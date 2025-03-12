using aula_03;

namespace aula_03.Test;

[TestClass]
public class TelevisaoTest
{
    [TestMethod]
    public void Dado_Tamanho_21_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(21f), $"O tamanho(21) não é suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_81_Deve_Retornar_Excecao()
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Televisao(81f), $"O tamanho(81) não é suportado!");
    }

    [TestMethod]
    public void Dado_Tamanho_25_Deve_Criar_Instancia()
    {
        const float tamanho = 25f;

        Televisao televisao = new Televisao(tamanho);
        Assert.IsInstanceOfType(televisao, typeof(Televisao));
        Assert.AreEqual(tamanho, televisao.Tamanho);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Volume_10()
    {
        const int volumePadrao = 10;

        Televisao televisao = new Televisao(25f);
        Assert.AreEqual(volumePadrao, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_11_Apos_Aumentar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.AumentarVolume();
        Assert.AreEqual(11, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ter_Volume_09_Apos_Diminuir_Volume()
    {
        Televisao televisao = new Televisao(25f);
        televisao.DiminuirVolume();
        Assert.AreEqual(09, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Restaurar_Volume_Anterior_Ao_Desmutar()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        televisao.AlternarModoMudo(); // Desmuta

        Assert.AreEqual(volumeInicial, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Estado_Correto_Com_Multiplas_Alternancias_Mudo()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo(); // Muta
        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo(); // Desmuta
        Assert.AreEqual(volumeInicial, televisao.Volume);

        televisao.AlternarModoMudo(); // Muta novamente
        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Ignorar_Mudancas_Volume_Durante_Mudo()
    {
        Televisao televisao = new Televisao(25f);

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();
        televisao.DiminuirVolume();

        Assert.AreEqual(0, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Manter_Mudo_Ao_Tentar_Alterar_Volume()
    {
        Televisao televisao = new Televisao(25f);
        const int volumeInicial = 10;

        televisao.AlternarModoMudo();
        televisao.AumentarVolume();

        Assert.AreEqual(0, televisao.Volume);

        televisao.AlternarModoMudo();
        Assert.AreEqual(volumeInicial, televisao.Volume);
    }

    [TestMethod]
    public void Deve_Estar_Canal_4_Ao_Criar_Instancia()
    {
        Televisao televisao = new Televisao(43);
        Assert.AreEqual(4, televisao.Canal);
    }
    [TestMethod]
    public void Deve_Retornar_Canal_3_Ao_Diminuir_Canal_Apos_Criacao()
    {
        Televisao televisao = new Televisao(43);
        televisao.DiminuirCanal();

        Assert.AreEqual(3, televisao.Canal);
    }

    [TestMethod]
    public void Deve_Retornar_Canal_5_Ao_Diminuir_Canal_Apos_Criacao()
    {
        Televisao televisao = new Televisao(43);
        televisao.DiminuirCanal();

        Assert.AreEqual(5, televisao.Canal);
    }

    [TestMethod]
    public void Deve_Retornar_Erro_Canal_Não_Existe_Valor_Minimo()
    {
        Televisao televisao = new Televisao(43);
        const int canal_teste = 0;

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => televisao.SelecionarCanal(canal_teste), $"O canal selecionado ({canal_teste}) não existe!\nPor favor selecione entre 1 e 10.");
    }

    [TestMethod]
    public void Deve_Retornar_Erro_Canal_Não_Existe_Valor_Maximo()
    {
        Televisao televisao = new Televisao(43);
        const int canal_teste = 11;

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => televisao.SelecionarCanal(canal_teste), $"O canal selecionado ({canal_teste}) não existe!\nPor favor selecione entre 1 e 10.");
    }
}