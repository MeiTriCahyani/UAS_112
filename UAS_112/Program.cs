using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_112
{
    class Node
    {
        public int NIM;
        public string nama;
        public string kelas;
        public Node next;
        public Node prev;
    }

    class CircularLinked
    {
        Node LAST;
        public CircularLinked()
        {
            LAST = null;
        }
        public void insertnode()
        {
            int nim;
            string nm;
            string kls;
            Console.WriteLine("\n masukkan nomor induk murid: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Maukkan nama murid :");
            nm = Console.ReadLine();
            Console.WriteLine("\n Masukkan kelas dari murid:");
            kls = Console.ReadLine();
            Node newNode = new Node();
            newNode.NIM = nim;
            newNode.nama = nm;
            newNode.kelas=kls;

            if (LAST == null)
            {
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            else if (nim <= LAST.NIM)
            {
                if (LAST != null && nim == LAST.NIM)
                {
                    Console.WriteLine("\n Dupliacte student number are not allowed \n");
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            Node previous, current;
            for (current = previous = LAST; current != null && nim >= current.NIM; previous = current, current = current.next)
            {
                if (nim == current.NIM)
                {
                    Console.WriteLine("\nDulicate nim not allowed");
                    return;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;
        }
        public bool Search(string Class, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (Class == current.kelas)
                    return (true);
            }
            if (Class == LAST.kelas)
                return true;
            else
                return (false);
        }
        
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\n Record in the list are : \n");
                Node currentNode;
                currentNode = LAST.next;
                for (currentNode = LAST; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.NIM+ " " + currentNode.nama + "\n"+ currentNode.kelas+ "\n");
                Console.WriteLine();
            }
        }
        public void firstnode()
        {
            if (listEmpty())
                Console.WriteLine("\nlist is empty");
            else
                Console.WriteLine("\nThe first record in the list is \n\n" + LAST.next.NIM + " " + LAST.next.nama + LAST.next.kelas);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinked obj = new CircularLinked();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Tambahkan data");
                    Console.WriteLine("2. Tampilkan semua data yang tersimpan");
                    Console.WriteLine("3. Mencari data kelas yang tersimpan");
                    Console.WriteLine("4. Menampilkan data pertama yang tersimpan");
                    Console.WriteLine("5. EXIT\n");
                    Console.WriteLine("Pilih menu (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insertnode();
                            }
                            break;
                     
                        case '2':
                            {
                                obj.traverse();
                            }
                            break;
                        case '3':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nMasukkan data kelas yang ingin dicari: ");
                                string kelas =Console.ReadLine();
                                if (obj.Search(kelas, ref prev, ref curr) == false)
                                    Console.WriteLine("\nData kelas tidak dapat ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData kelas ditemukan");
                                    Console.WriteLine("\nNIM: " + curr.NIM);
                                    Console.WriteLine("\nName: " + curr.nama);
                                    Console.WriteLine("\nKelas:" + curr.kelas);
                                }
                            }
                            break;
                        case '4':
                            {
                                obj.firstnode();
                            }
                            break;
                        case '5':
                            {
                                return;
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}

//2. algoritma class node, circular linkedlist, insert node, search, list empty, traverse, firstnode
//3. TOP merupakan data yang bisa disimpan dan dikeluarkan hanya melalui satu pintu terakhir
//4. REAR dan FRONT
//5.A. 4 level
//B.Inorder
//15,25,20,31,35,32,30,48,50,66,69,67,65,94,99,98,90,70


