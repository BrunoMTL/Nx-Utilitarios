using System;
using System.IO;
using NXOpen;

public class ListarPostsLocal
{
    public static int Main(string[] args)
    {
        Session s = Session.GetSession();
        ListingWindow lw = s.ListingWindow;
        lw.Open();

        string postDir = @"C:\Users\rogerio\Documents\resource\postprocessor";
        lw.WriteLine("=== POSTS (DIR LOCAL) ===");
        lw.WriteLine("Pasta: " + postDir);

        if (!Directory.Exists(postDir))
        {
            lw.WriteLine("ERRO: pasta não existe.");
            return 0;
        }

        // extensões mais comuns de post (dependendo do setup)
        string[] patterns = new string[] { "*.tcl", "*.def", "*.pui", "*.post", "*.*" };

        // CSV de saída
        string outCsv = Path.Combine(postDir, "_posts_index.csv");
        using (var sw = new StreamWriter(outCsv, false))
        {
            sw.WriteLine("file_name;ext;full_path");

            foreach (string pat in patterns)
            {
                string[] files;
                try
                {
                    files = Directory.GetFiles(postDir, pat, SearchOption.TopDirectoryOnly);
                }
                catch
                {
                    continue;
                }

                lw.WriteLine(pat + " : " + files.Length);

                foreach (string f in files)
                {
                    string name = Path.GetFileName(f);
                    string ext = Path.GetExtension(f);
                    lw.WriteLine("  " + name);
                    sw.WriteLine($"{name};{ext};{f}");
                }
            }
        }

        lw.WriteLine("----------------------------------------");
        lw.WriteLine("CSV gerado: " + outCsv);
        lw.WriteLine("=== FIM ===");
        return 0;
    }

    public static int GetUnloadOption(string dummy)
    {
        return (int)Session.LibraryUnloadOption.Immediately;
    }
}
