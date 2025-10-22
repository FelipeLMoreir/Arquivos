using ProjCarros;

string CarregarPrograma()
{
    string diretorio = @"C:\Locadora\Dados\";
    string arquivo = "carros.vsf";
    if (!Directory.Exists(diretorio))
    {
        Directory.CreateDirectory(diretorio);
    }
    if (!File.Exists(Path.Combine(diretorio, arquivo)))
    {
        File.Create(Path.Combine(diretorio, arquivo));
    }
    return Path.Combine(diretorio, arquivo);
}
List<Carro> LerArquivo()
{
    var caminhoCompleto = CarregarPrograma();

    StreamReader sr = new StreamReader(caminhoCompleto);

    using (sr)
    {
        if (sr.ReadToEnd() is null)//pode ser (sr.ReadToEnd().Length == 0) ou
                                   //(sr.ReadToEnd() is "")
        {
            return new List<Carro>();
        }
        else
        {
            List<Carro> carros = new List<Carro>();

            while (sr.ReadLine() is not null)
            {
                string linha = sr.ReadLine();
                var valores = linha.Split(",");
                Carro carro = new Carro(int.Parse(valores[0]), valores[1], valores[2],
                    int.Parse(valores[3]), valores[4], valores[5]);
                carros.Add(carro);
            }
            sr.Close();
            return carros;
        }
    }
}
void GravarArquivo(List<Carro> carros)
{
    var caminho = CarregarPrograma();

    StreamWriter sw = new StreamWriter(caminho);
    using (sw)
    {
        foreach (Carro carro in carros)
        {
            sw.WriteLine(carro.ToFile());
        }
        sw.Close();
    }
}

var locadora  = new Locadora(LerArquivo());

locadora.ListarTodosCarros();

locadora.CadastrarCarro();
locadora.CadastrarCarro();
locadora.CadastrarCarro();

locadora.ListarTodosCarros();
locadora.AtualizarCarro();
locadora.RemoverCarro();
locadora.ListarTodosCarros();

GravarArquivo(locadora.Carros);