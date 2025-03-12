namespace aula_03;

public class Televisao
{
    //O método construtor possui o mesmo nome da classe. 
    // Ele não possui retorno (nem mesmo o void)
    //Este método é executado sempre que uma instancia da classe
    //é criada.
    //Por padrão, o C# cria um método construtor publico vazio,
    //mas podemos criar métodos construtores com outras
    //visibilidades e recebendo parametros, se necessário.
    public Televisao(float tamanho)
    {
        if (tamanho < TAMANHO_MINIMO || tamanho > TAMANHO_MAXIMO)
        {
            throw new ArgumentOutOfRangeException($"O tamanho({tamanho}) não é suportado!");
        }
        Tamanho = tamanho;
        Volume = VOLUME_PADRAO;
        Mudo = MUDO_PADRAO;
        Canal = 4;
    }

    //Optamos pela utilização da constante para tornar o código mais legível.
    private const float TAMANHO_MINIMO = 22;
    private const float TAMANHO_MAXIMO = 80;
    private const int VOLUME_MAXIMO = 12;
    private const int VOLUME_MINIMO = 0;
    private const int VOLUME_PADRAO = 10;
    private const bool MUDO_PADRAO = false;
    private int _ultimoVolume = VOLUME_PADRAO;



    //Get: permite que seja executada a 
    //leitura do valor atual da propriedade
    //Set: permite que seja atibuído um 
    //valor para a propriedade

    //classes, propriedades e métodos possuem modificadores de acesso
    //public: visiveis a todo o projeto
    //internal: visiveis somente no namespace - padrão
    //protected: visiveis somente na classe e nas classes que herdam
    //private: visiveis somente na classe que foram criados
    public float Tamanho { get; }
    public int Resolucao { get; set; }
    public int Volume { get; private set; }
    public int Canal { get; set; }
    public bool Mudo { get; set; }

    public void AumentarVolume()
    {
        if (Volume < VOLUME_MAXIMO)
        {
            Volume++;
            _ultimoVolume = Volume;
        }
        else
        {
            Console.WriteLine("A TV já está no volume máximo permitido");
        }
    }

    public void DiminuirVolume()
    {
        if (Volume > VOLUME_MINIMO)
        {
            Volume--;
            _ultimoVolume = Volume;
        }
        else
        {
            Console.WriteLine("A TV já está no volume mínimo permitido");
        }
    }

    //1 botao de mudo -  toggle (on/off)
    //Volume = x; Volume = 0; Volume = x;
    public void AlternarModoMudo()
    {
        if (Mudo == false)
        {
            _ultimoVolume = Volume;
            Mudo = true;
            Console.WriteLine("A TV está no modo MUTE.");
        }
        else
        {
            Volume = _ultimoVolume;
            Mudo = false;
            Console.WriteLine($"O volume da TV é: {Volume}.");
        }
    }

    
    public void AumentarCanal(){
        if (Canal > 10)
        {
            Console.WriteLine($"A TV já está no canal máximo permitido({Canal}).");
        }
        else
        {
            Canal ++;
        }
    }

    public void DiminuirCanal()
    {
        if (Canal < 1)
        {
            Console.WriteLine($"A TV já está no canal mínimo permitido({Canal}).");
        }
        else 
        {
            Canal --;
        }
    }

    public void SelecionarCanal(int canal_selecionado)
    {
        if (canal_selecionado > 10 && canal_selecionado < 1)
        {
            throw new ArgumentOutOfRangeException($"O canal selecionado ({canal_selecionado}) não existe!\nPor favor selecione entre 1 e 10.");
        }
        else 
        {
            Canal = canal_selecionado;
            Console.WriteLine($"O canal '{canal_selecionado}' foi selecionado!");
        }
    }
}