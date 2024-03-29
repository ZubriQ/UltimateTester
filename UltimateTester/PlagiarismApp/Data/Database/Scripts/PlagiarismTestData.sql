USE [Plagiarism]
GO
SET IDENTITY_INSERT [dbo].[project_type] ON 

INSERT [dbo].[project_type] ([id], [name], [description]) VALUES (1, N'Lab 1 C#', N'Classes creation')
INSERT [dbo].[project_type] ([id], [name], [description]) VALUES (2, N'Lab 2 C#', N'Paint')
INSERT [dbo].[project_type] ([id], [name], [description]) VALUES (3, N'Lab 3 C#', N'WPF')
INSERT [dbo].[project_type] ([id], [name], [description]) VALUES (4, N'Lab 4 C#', N'Integration')
INSERT [dbo].[project_type] ([id], [name], [description]) VALUES (1002, N'Lab 5 C#', N'WinForms')
INSERT [dbo].[project_type] ([id], [name], [description]) VALUES (2010, N'Lab 6 C#', N'AI')
INSERT [dbo].[project_type] ([id], [name], [description]) VALUES (2011, N'Lab 7 C#', N'Web')
SET IDENTITY_INSERT [dbo].[project_type] OFF
GO
SET IDENTITY_INSERT [dbo].[group] ON 

INSERT [dbo].[group] ([id], [name], [year]) VALUES (1, N'ПИБ-01.1', 2002)
INSERT [dbo].[group] ([id], [name], [year]) VALUES (2, N'ПИБ-01.2', 2002)
INSERT [dbo].[group] ([id], [name], [year]) VALUES (2026, N'ОБ-09', 2004)
INSERT [dbo].[group] ([id], [name], [year]) VALUES (2027, N'ДАБ-64', 2004)
INSERT [dbo].[group] ([id], [name], [year]) VALUES (2029, N'ФК-37', 2008)
SET IDENTITY_INSERT [dbo].[group] OFF
GO
SET IDENTITY_INSERT [dbo].[student] ON 

INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (1, N'Mitya', N'Popo', N'Eugenievich', 2)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (2, N'Egor', N'Egorov', NULL, 2)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (3, N'Stanivlas', N'Mironov', NULL, 1)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (4, N'Gedeon', N'Tarasov', N'Tarasovich', 1)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (5, N'Nikita', N'Novikov', NULL, 1)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (6, N'Zina', N'Volkova', N'Potapovna', 1)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (1003, N'Гена', N'Мухин', N'Максимович', 2)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (1010, N'Митрофан', N'Чернов', N'Платонович', 2026)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (1011, N'Олег', N'Петухов', N'Ефимович', 2)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (1012, N'Флор', N'Мишин', N'Иосифович', 2026)
INSERT [dbo].[student] ([id], [first_name], [surname], [patronymic], [group_id]) VALUES (1013, N'Злата', N'Калашникова', N'Константиновна', 2029)
SET IDENTITY_INSERT [dbo].[student] OFF
GO
SET IDENTITY_INSERT [dbo].[project] ON 

INSERT [dbo].[project] ([id], [name], [git_url], [path_on_disc], [student_id], [project_type_id], [originality_percentage], [date_of_passing]) VALUES (80, N'Lab2.zip', NULL, N'E:\UT\UltimateTester\UltimateTester\PlagiarismApp\UploadedProjects\ПИБ-02\Popo Mitya Eugenievich\Lab 1 C#\Lab2.zip', 1, 1, 1, CAST(N'2023-01-09T20:54:50.833' AS DateTime))
INSERT [dbo].[project] ([id], [name], [git_url], [path_on_disc], [student_id], [project_type_id], [originality_percentage], [date_of_passing]) VALUES (81, N'Lab3.zip', NULL, N'E:\UT\UltimateTester\UltimateTester\PlagiarismApp\UploadedProjects\ПИБ-01.1\Novikov Nikita\Lab 2 C#\Lab3.zip', 5, 2, 0.74, CAST(N'2023-01-09T20:55:06.893' AS DateTime))
INSERT [dbo].[project] ([id], [name], [git_url], [path_on_disc], [student_id], [project_type_id], [originality_percentage], [date_of_passing]) VALUES (82, N'Lab6.zip', NULL, N'E:\UT\UltimateTester\UltimateTester\PlagiarismApp\UploadedProjects\ПИБ-01.1\Mironov Stanivlas\Lab 3 C#\Lab6.zip', 3, 3, 0.6, CAST(N'2023-01-09T20:55:22.970' AS DateTime))
INSERT [dbo].[project] ([id], [name], [git_url], [path_on_disc], [student_id], [project_type_id], [originality_percentage], [date_of_passing]) VALUES (83, N'Lab9_Photo_studio.zip', NULL, N'E:\UT\UltimateTester\UltimateTester\PlagiarismApp\UploadedProjects\ПИБ-02\Мухин Гена Максимович\Lab 5 C#\Lab9_Photo_studio.zip', 1003, 1002, 0.55, CAST(N'2023-01-09T20:55:35.973' AS DateTime))
INSERT [dbo].[project] ([id], [name], [git_url], [path_on_disc], [student_id], [project_type_id], [originality_percentage], [date_of_passing]) VALUES (84, N'Lab2.zip', NULL, N'E:\UT\UltimateTester\UltimateTester\PlagiarismApp\UploadedProjects\ОБ-09\Чернов Митрофан Платонович\Lab 1 C#\Lab2.zip', 1010, 1, 0, CAST(N'2023-01-09T20:55:53.167' AS DateTime))
INSERT [dbo].[project] ([id], [name], [git_url], [path_on_disc], [student_id], [project_type_id], [originality_percentage], [date_of_passing]) VALUES (85, N'Lab7.zip', NULL, N'E:\UT\UltimateTester\UltimateTester\PlagiarismApp\UploadedProjects\ФК-7\Калашникова Злата Константиновна\Lab 3 C#\Lab7.zip', 1013, 3, 0.71, CAST(N'2023-01-09T20:56:14.787' AS DateTime))
INSERT [dbo].[project] ([id], [name], [git_url], [path_on_disc], [student_id], [project_type_id], [originality_percentage], [date_of_passing]) VALUES (86, N'Lab5_Regex.zip', NULL, N'E:\UT\UltimateTester\UltimateTester\PlagiarismApp\UploadedProjects\ПИБ-01.1\Novikov Nikita\Lab 6 C#\Lab5_Regex.zip', 5, 2010, 0.66, CAST(N'2023-01-09T20:56:33.723' AS DateTime))
SET IDENTITY_INSERT [dbo].[project] OFF
GO
