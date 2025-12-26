using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7.Lib
{
    public class DataService_DEV
    {
        private const int ColumnCount = 11;

        public DataTable CreateTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("EntranceNumber", typeof(int));
            table.Columns.Add("ApartmentNumber", typeof(int));
            table.Columns.Add("TotalArea", typeof(double));
            table.Columns.Add("LivingArea", typeof(double));
            table.Columns.Add("RoomsCount", typeof(int));
            table.Columns.Add("TenantLastName", typeof(string));
            table.Columns.Add("RegistrationDate", typeof(string));
            table.Columns.Add("FamilyMembers", typeof(int));
            table.Columns.Add("ChildrenCount", typeof(int));
            table.Columns.Add("HasDebt", typeof(string)); // СТРОКА!
            table.Columns.Add("Note", typeof(string));

            return table;
        }

        public DataTable LoadFromCsv_DEV(string path)
        {
            DataTable table = CreateTable();

            if (!File.Exists(path))
                return table;

            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            if (lines.Length == 0) return table;

            int startIndex = lines[0].Contains("НомерПодъезда") ? 1 : 0;

            for (int i = startIndex; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line)) continue;

                string[] parts = line.Split(',');
                if (parts.Length < ColumnCount)
                    parts = parts.Concat(Enumerable.Repeat("", ColumnCount - parts.Length)).ToArray();

                // Преобразуем в строку "да" или "нет"
                string debtValue = parts[9].Trim().ToLower();
                string hasDebtStr = "нет";

                if (debtValue == "да" || debtValue == "true" || debtValue == "1")
                    hasDebtStr = "да";
                else if (debtValue == "нет" || debtValue == "false" || debtValue == "0")
                    hasDebtStr = "нет";

                table.Rows.Add(
                    ToInt(parts[0]),
                    ToInt(parts[1]),
                    ToDouble(parts[2]),
                    ToDouble(parts[3]),
                    ToInt(parts[4]),
                    parts[5],
                    parts[6],
                    ToInt(parts[7]),
                    ToInt(parts[8]),
                    hasDebtStr, // Сохраняем как строку
                    parts[10]
                );
            }

            return table;
        }

        public void SaveToCsv_DEV(string path, DataTable table)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(
                "НомерПодъезда,НомерКвартиры,ОбщаяПлощадь,ЖилаяПлощадь,КоличествоКомнат," +
                "Фамилия,ДатаРегистрации,ЧленовСемьи,КоличествоДетей,НаличиеДолга,Примечание");

            foreach (DataRow row in table.Rows)
            {
                sb.AppendLine(string.Join(",",
                    row["EntranceNumber"],
                    row["ApartmentNumber"],
                    ((double)row["TotalArea"]).ToString("F2", CultureInfo.InvariantCulture),
                    ((double)row["LivingArea"]).ToString("F2", CultureInfo.InvariantCulture),
                    row["RoomsCount"],
                    Escape(row["TenantLastName"]),
                    row["RegistrationDate"],
                    row["FamilyMembers"],
                    row["ChildrenCount"],
                    row["HasDebt"], // Уже строка "да"/"нет"
                    Escape(row["Note"])
                ));
            }

            Directory.CreateDirectory(Path.GetDirectoryName(path)!);
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        private int ToInt(string v) =>
            int.TryParse(v, out int r) ? r : 0;

        private double ToDouble(string v)
        {
            v = v.Replace(',', '.');
            return double.TryParse(v, NumberStyles.Any, CultureInfo.InvariantCulture, out double r) ? r : 0;
        }

        private string Escape(object v) =>
            v?.ToString()?.Replace(",", " ") ?? "";
    }
}