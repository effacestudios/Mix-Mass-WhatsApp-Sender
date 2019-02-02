using System;
using System.Windows;
using System.IO;
using System.Diagnostics;
using IronPython.Hosting;
using System.Collections.Generic;
using System.Text;
using Microsoft.Scripting.Hosting;

namespace MassWhatsAppSender___Bulk_Sender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter PyCode = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory + "PyCode.py");
            PyCode.AutoFlush = true;
            PyCode.Flush();
            PyCode.WriteLine("from time import sleep");
            PyCode.WriteLine("from selenium.webdriver.common.by import By");
            PyCode.WriteLine("from selenium import webdriver");
            PyCode.WriteLine("from selenium.webdriver.common.keys import Keys");
            PyCode.WriteLine("from selenium.webdriver.support import expected_conditions as EC");
            PyCode.WriteLine("from selenium.common.exceptions import TimeoutException");
            PyCode.WriteLine("from selenium.webdriver.support.ui import WebDriverWait");
            PyCode.WriteLine("import socket");
            PyCode.WriteLine("message_text='" + Msgbox.Text + "' # message you want to send");
            PyCode.WriteLine("no_of_message="+NumofMessages.Text+" # no. of time you want the message to be send");
            PyCode.WriteLine("moblie_no_list=["+Numbersbox.Text+"] # list of phone number can be of any length");
            PyCode.WriteLine("def element_presence(by,xpath,time):");
            PyCode.WriteLine("    element_present = EC.presence_of_element_located((By.XPATH, xpath))");
            PyCode.WriteLine("    WebDriverWait(driver, time).until(element_present)");
            PyCode.WriteLine("def is_connected():");
            PyCode.WriteLine("    try:");
            PyCode.WriteLine("        # connect to the host -- tells us if the host is actually");
            PyCode.WriteLine("        # reachable");
            PyCode.WriteLine("        socket.create_connection((\"www.google.com\", 80))");
            PyCode.WriteLine("        return True");
            PyCode.WriteLine("    except :");
            PyCode.WriteLine("        is_connected()");
            PyCode.WriteLine("driver = webdriver.Chrome(executable_path=\"chromedriver.exe\")");
            PyCode.WriteLine("driver.get(\"http://web.whatsapp.com\")");
            PyCode.WriteLine("sleep(10) #wait time to scan the code in second");
            PyCode.WriteLine("def send_whatsapp_msg(phone_no,text):");
            PyCode.WriteLine("    driver.get(\"https://web.whatsapp.com/send?phone={}&source=&data=#\".format(phone_no))");
            PyCode.WriteLine("    try:");
            PyCode.WriteLine("        driver.switch_to_alert().accept()");
            PyCode.WriteLine("    except Exception as e:");
            PyCode.WriteLine("        pass");
            PyCode.WriteLine("    try:");
            PyCode.WriteLine("        element_presence(By.XPATH,'//*[@id=\"main\"]/footer/div[1]/div[2]/div/div[2]',30)");
            PyCode.WriteLine("        txt_box=driver.find_element(By.XPATH , '//*[@id=\"main\"]/footer/div[1]/div[2]/div/div[2]')");
            PyCode.WriteLine("        global no_of_message");
            PyCode.WriteLine("        for x in range(no_of_message):");
            PyCode.WriteLine("            txt_box.send_keys(text)");
            PyCode.WriteLine("            txt_box.send_keys(\"\\n\")");
            PyCode.WriteLine("    except Exception as e:");
            PyCode.WriteLine("        print(\"invailid phone no: \"+str(phone_no))");
            PyCode.WriteLine("for moblie_no in moblie_no_list:");
            PyCode.WriteLine("    try:");
            PyCode.WriteLine("        send_whatsapp_msg(moblie_no,message_text)");
            PyCode.WriteLine("    except Exception as e:");
            PyCode.WriteLine("        sleep(10)");
            PyCode.WriteLine("        is_connected()");
            PyCode.Close();




            System.Diagnostics.Process.Start("CMD.exe", "/K python PyCode.py");







        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Numbersbox.Items.Add(Number.Text);
          
        }

     
        private void RemoveBtn_Click_1(object sender, RoutedEventArgs e)
        {
            //Numbersbox.Items.RemoveAt(Numbersbox.Items.IndexOf(Numbersbox.SelectedItem));
          
        }
    }
}
