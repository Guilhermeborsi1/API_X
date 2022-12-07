using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_X.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Produto : ControllerBase
    {
        [HttpGet]
        public string List1(string p_nome1)

        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=TI_Noite;User ID=Turma2022;Password=Turma2022@2022";
            DataSet resultadoCEP1 = new DataSet();

            SqlConnection Conexao = new SqlConnection(Chaveconexao);
            Conexao.Open();

            string wQuery = $"select * from Produto where Nome_produto like '%{p_nome1}%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
            adapter.Fill(resultadoCEP1);

            string json = JsonConvert.SerializeObject(resultadoCEP1, Formatting.Indented);

            return json;
        }
    }
}
