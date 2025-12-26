using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using Tyuiu.DevyatovEV.Sprint7.Project.V7.Lib;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7.Test
{
    [TestClass]
    public sealed class DataServiceTest_DEV
    {
        private string testFilePath = null!;
        private string outFilePath = null!;

        [TestInitialize]
        public void Setup()
        {
            // Создаем временные файлы для тестов
            testFilePath = Path.Combine(
                Path.GetTempPath(),
                $"test_{Guid.NewGuid()}.csv");

            outFilePath = Path.Combine(
                Path.GetTempPath(),
                $"output_{Guid.NewGuid()}.csv");

            // Создаем тестовый CSV файл с разделителем ;
            File.WriteAllText(testFilePath,
                "НомерПодъезда;НомерКвартиры;ОбщаяПлощадь;ЖилаяПлощадь;КоличествоКомнат;Фамилия;ДатаРегистрации;ЧленовСемьи;КоличествоДетей;НаличиеДолга;Примечание\n" +
                "1;1;45.6;32.4;2;Иванов;2015-03-12;3;1;нет;—\n" +
                "2;5;60.0;40.0;3;Петров;2012-06-25;4;2;да;Долг за коммуналку\n" +
                "3;12;85.5;60.2;4;Сидоров;2020-01-15;5;3;нет;Многодетная семья\n" +
                "1;3;33.3;25.0;1;Кузнецов;2018-11-30;2;0;да;Временно не проживает",
                Encoding.UTF8);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Удаляем временные файлы после тестов
            try
            {
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);

                if (File.Exists(outFilePath))
                    File.Delete(outFilePath);
            }
            catch
            {
                // Игнорируем ошибки удаления файлов
            }
        }
    }
}