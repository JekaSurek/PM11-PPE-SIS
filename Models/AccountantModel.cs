    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УчетСИЗ.Models
{
    public class AccountantModel
    {
        public class NormInfo
        {
            public int NormId { get; set; }
            public string Infrastructure { get; set; }
            public string Profession { get; set; }
            public string SIZ { get; set; }
            public string SIZType { get; set; }
            public string Unit { get; set; }
            public string Norm { get; set; }
            public string Period { get; set; }
            public string Season { get; set; }
            public string Basis { get; set; }
        }

        public List<NormInfo> GetNormsData()
        {
            var norms = new List<NormInfo>();
            string connectionString = DatabaseHelper.GetConnectionString();

            string sql = @"
                SELECT 
                    n.id_Нормы,
                    i.Наименование AS Инфраструктура,
                    p.Наименование AS Профессия,
                    s.Наименование AS СИЗ,
                    ts.Наименование AS ТипСИЗ,
                    s.Единица_измерения,
                    n.Норма_в_единицах_измерения,
                    n.Период,
                    sz.Наименование AS Сезон,
                    n.Основание_назначения
                FROM НормаВыдачи n
                JOIN Профессия p ON n.id_профессии = p.id_Профессии_или_должности
                JOIN Инфраструктура i ON p.id_инфраструктуры_или_отдела = i.id_Инфраструктуры
                JOIN СИЗ s ON n.id_сиз = s.id_СИЗ
                JOIN ТипСИЗ ts ON s.id_типаСИЗ = ts.id_Типа
                JOIN Сезон sz ON n.Сезон = sz.id_Сезона
                ORDER BY i.Наименование, p.Наименование";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        norms.Add(new NormInfo
                        {
                            NormId = reader.GetInt32(0),
                            Infrastructure = reader.GetString(1),
                            Profession = reader.GetString(2),
                            SIZ = reader.GetString(3),
                            SIZType = reader.GetString(4),
                            Unit = reader.GetString(5),
                            Norm = reader.GetString(6),
                            Period = reader.GetString(7),
                            Season = reader.GetString(8),
                            Basis = reader.GetString(9)
                        });
                    }
                }
            }

            return norms;
        }
    }
}
