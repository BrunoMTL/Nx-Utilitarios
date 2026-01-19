using System;
using NXOpen;
using NXOpen.CAM;

public class ListarOperacoesPorPrograma
{
    public static int Main(string[] args)
    {
        Session theSession = Session.GetSession();
        Part workPart = theSession.Parts.Work;
        ListingWindow lw = theSession.ListingWindow;
        lw.Open();

        if (workPart == null)
        {
            lw.WriteLine("Nenhuma peça ativa.");
            return 0;
        }

        if (workPart.CAMSetup == null)
        {
            lw.WriteLine("Peça sem setup CAM.");
            return 0;
        }

        CAMSetup setup = workPart.CAMSetup;
        OperationCollection opCollection = setup.CAMOperationCollection;

        NXOpen.CAM.Operation[] ops = opCollection.ToArray();

        lw.WriteLine("=== OPERACOES CAM POR PROGRAMA (PROGRAM VIEW) ===");
        lw.WriteLine("Total de operações: " + ops.Length.ToString());
        lw.WriteLine("");

        int idx = 1;

        foreach (NXOpen.CAM.Operation op in ops)
        {
            NCGroup progGroup =
                op.GetParent(NXOpen.CAM.CAMSetup.View.ProgramOrder) as NCGroup;

            string progName = progGroup != null ? progGroup.Name : "<sem programa>";

            string linha = string.Format(
                "{0:000} - PROGRAMA: {1}  |  OP: {2}  |  Tipo: {3}",
                idx,
                progName,
                op.Name,
                op.GetType().Name
            );

            lw.WriteLine(linha);
            idx++;
        }

        return 0;
    }

    public static int GetUnloadOption(string dummy)
    {
        return (int)Session.LibraryUnloadOption.Immediately;
    }
}
