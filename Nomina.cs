﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProgramaDeFactoracion {
    public class Nomina {
        List<Trabajador> listaTrabajadores = new List<Trabajador>();
        string connectionString = "datasource=localhost;port=3306;username=root;password=;database=nomina;";

        private Trabajador completeData(Trabajador t) {            
            t.transporte = 102854;
            t.nhedValor = t.nhed * 4572;
            t.nhenValor = t.nhen * 6401;
            t.nheddValor = t.nhedd * 7315;
            t.nhednValor = t.nhedn * 9144;
            t.nhrnValor = t.nhrn * 1280;
            t.extras = t.nhedValor + t.nhenValor + t.nheddValor + t.nhednValor + t.nhrnValor;
            t.devengado = t.extras + (t.sueldo/24 * t.dias);
            t.salud = Convert.ToInt32(t.sueldo * 0.04);
            t.pension = Convert.ToInt32(t.sueldo * 0.04);
            if(t.sueldo>=(877803*4)) {
                t.solidiario = Convert.ToInt32(t.sueldo * 0.01);
            }
            t.uvt = t.sueldo / 35607;
            if (t.uvt >= 95) {
                t.retefuente = Convert.ToInt32(t.sueldo * 0.015);
            }
            t.deducido = t.salud + t.pension + t.solidiario + t.retefuente;
            t.neto = t.devengado - t.deducido;
            return t;
        }

        public void insertIntoDB(Trabajador newTrabajador) {
            newTrabajador = completeData(newTrabajador);
            string query = "INSERT INTO employees " +
                "(`cedula`, `nombre`, `sueldo`, `dias`, `nhed`, `nhen`, `nhedd`, `nhedn`, `nhrn`, `transporte`, `nhedv`, `nhenv`, `nheddv`, `nhednv`, `nhrnv`, `extras`, `devengado`, `salud`, `pension`, `solidario`, `uvt`, `retefuente`, `deducido`, `neto`) VALUES " +
                "(" + newTrabajador.cedula + ", '" + newTrabajador.nombre + "', " + newTrabajador.sueldo + ", " + newTrabajador.dias + ", " + newTrabajador.nhed + ", " + newTrabajador.nhen + ", " + newTrabajador.nhedd + ", " + newTrabajador.nhedn + ", " + newTrabajador.nhrn + ", " + newTrabajador.transporte + ", " + newTrabajador.nhedValor + ", " + newTrabajador.nhenValor + ", " + newTrabajador.nheddValor + ", " + newTrabajador.nhednValor + ", " + newTrabajador.nhrnValor + ", " + newTrabajador.extras + ", " + newTrabajador.devengado + ", " + newTrabajador.salud + ", " + newTrabajador.pension + ", " + newTrabajador.solidiario + ", " + newTrabajador.uvt + ", " + newTrabajador.retefuente + ", " + newTrabajador.deducido + ", " + newTrabajador.neto + ")";
            Console.WriteLine(query);
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Trabajador> getDataDB() {
            listaTrabajadores.Clear();
            string query = "SELECT * FROM employees WHERE 1";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows) {
                    while (reader.Read()) {
                        Trabajador newT = new Trabajador(
                            Convert.ToInt32(reader.GetString(0)),
                            reader.GetString(1),
                            Convert.ToInt32(reader.GetString(2)),
                            Convert.ToInt32(reader.GetString(3)),
                            Convert.ToInt32(reader.GetString(4)),
                            Convert.ToInt32(reader.GetString(5)),
                            Convert.ToInt32(reader.GetString(6)),
                            Convert.ToInt32(reader.GetString(7)),
                            Convert.ToInt32(reader.GetString(8)),
                            Convert.ToInt32(reader.GetString(9)),
                            Convert.ToInt32(reader.GetString(10)),
                            Convert.ToInt32(reader.GetString(11)),
                            Convert.ToInt32(reader.GetString(12)),
                            Convert.ToInt32(reader.GetString(13)),
                            Convert.ToInt32(reader.GetString(14)),
                            Convert.ToInt32(reader.GetString(15)),
                            Convert.ToInt32(reader.GetString(16)),
                            Convert.ToInt32(reader.GetString(17)),
                            Convert.ToInt32(reader.GetString(18)),
                            Convert.ToInt32(reader.GetString(19)),
                            Convert.ToInt32(reader.GetString(20)),
                            Convert.ToInt32(reader.GetString(21)),
                            Convert.ToInt32(reader.GetString(22)),
                            Convert.ToInt32(reader.GetString(23))
                            );
                        listaTrabajadores.Add(newT);
                    }
                } else {
                    Console.WriteLine("Didn't not find data.");
                }
                databaseConnection.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return listaTrabajadores;
        }

        public Trabajador getOneData(int cedula) {
            getDataDB();
            foreach (var t in listaTrabajadores) {
                if(t.cedula == cedula) {
                    return t;
                }
            }
            return null;
        }

        public void deleteData(int cedula) {
            string query = "DELETE FROM employees WHERE `cedula` = " + cedula;
            Console.WriteLine(query);
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

    }
}