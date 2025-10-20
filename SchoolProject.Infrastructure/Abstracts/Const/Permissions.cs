namespace SchoolProject.Api.Const
{
    public static class Permissions
    {
        public static string Type { get; } = "permissions";

        // 🎓 Student Permissions
        public const string GetStudents = "Students:Read";
        public const string AddStudent = "Students:Add";
        public const string UpdateStudent = "Students:Update";
        public const string DeleteStudent = "Students:Delete";

        // 🏫 Department Permissions
        public const string GetDepartments = "Departments:Read";
        public const string AddDepartment = "Departments:Add";
        public const string UpdateDepartment = "Departments:Update";
        public const string DeleteDepartment = "Departments:Delete";

        // 👨‍🏫 Instructor Permissions
        public const string GetInstructors = "Instructors:Read";
        public const string AddInstructor = "Instructors:Add";
        public const string UpdateInstructor = "Instructors:Update";
        public const string DeleteInstructor = "Instructors:Delete";

        // 📚 Subject Permissions
        public const string GetSubjects = "Subjects:Read";
        public const string AddSubject = "Subjects:Add";
        public const string UpdateSubject = "Subjects:Update";
        public const string DeleteSubject = "Subjects:Delete";

        // 🧑‍💼 User & Roles Management
        public const string GetUsers = "Users:Read";
        public const string AddUsers = "Users:Add";
        public const string UpdateUsers = "Users:Update";
        public const string DeleteUsers = "Users:Delete";

        public const string GetRoles = "Roles:Read";
        public const string AddRoles = "Roles:Add";
        public const string UpdateRoles = "Roles:Update";
        public const string DeleteRoles = "Roles:Delete";

        // 🔐 Authorization / Role Assignment
        public const string AssignRoleToUser = "Authorization:AssignRole";
        public const string RemoveRoleFromUser = "Authorization:RemoveRole";

        // 🧾 Results / Grades Permissions
        public const string GetResults = "Results:Read";
        public const string AddResults = "Results:Add";
        public const string UpdateResults = "Results:Update";
        public const string DeleteResults = "Results:Delete";

        // ⚙️ Helper method to get all permissions
        public static IList<string?> GetAllPermissions() =>
            typeof(Permissions)
                .GetFields()
                .Where(f => f.IsLiteral && !f.IsInitOnly)
                .Select(x => x.GetValue(null) as string)
                .ToList();
    }
}
