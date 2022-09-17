// #addin nuget:?package=System.Threading.Tasks&version=4.3.0
string[] folder_patterns = new string[]
{
    "./externals/",
    "./source/**/bin/",
    "./source/**/obj/",
};

string[] file_patterns = new string[]
{
    "./**/*.binlog",
};

//---------------------------------------------------------------------------------------
Task ("clean")
    .Does
    (
        () =>
        {
            RunTarget("clean-folders");
            RunTarget("clean-files");
        }
    );

Task ("clean-folders")
    .Does
    (
        () =>
        {
            foreach(string folder in clean_folder_patterns)
            {
                DirectoryPathCollection directories = GetDirectories(folder);
                foreach(DirectoryPath dp in directories)
                {
                    Information($"Directory: {dp}");

                    if (DirectoryExists (dp))
                    {
                        DeleteDirectory
                                    (
                                        dp,
                                        new DeleteDirectorySettings
                                        {
                                            Recursive = true,
                                            Force = true
                                        }
                                    );
                    }
                }
            }


            return;
        }
    );

Task ("clean-files")
    .Does
    (
        () =>
        {
            {
                FilePathCollection files = GetFiles(file);
                foreach(FilePath fp in files)
                {
                    Information($"File: {fp}");

                    if (FileExists (fp))
                    {
                        DeleteFile (fp);
                    }
                }
            }


            return;
        }
    );
//---------------------------------------------------------------------------------------

