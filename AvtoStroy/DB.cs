using AvtoStroy.DataSet1TableAdapters;


namespace AvtoStroy
{
    public static class DB
    {
        public static DataSet1 dataSet = new();
        public static work_section1TableAdapter work_SectionAdapter = new();
        public static brigades1TableAdapter brigadesAdapter = new();
        public static postsTableAdapter postAdapter = new();
        public static employeeTableAdapter employeeAdapter = new();
        public static specialisationTableAdapter specialisationAdapter = new();
        public static workshopTableAdapter workshopAdapter = new();
        public static laboratoriesTableAdapter laboratoriesAdapter = new();
        public static usersTableAdapter usersAdapter = new();
        public static rolesTableAdapter rolesAdapter = new();

        public static ProductTableAdapter productAdapter = new();
        public static WorkSectionTableAdapter workSectionAdapter = new();
        public static Workers_in_brigadesTableAdapter workers_In_BrigadesAdapter = new();
        public static CehTableAdapter cehAdapter = new();
        public static EmployessTableAdapter employessTableAdapter = new();
    }
}
