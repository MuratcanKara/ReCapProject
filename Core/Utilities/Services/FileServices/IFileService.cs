﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public interface IFileService
    {
        string SaveImage(IFormFile file, string root);
        void Delete(string filePath);
        string Update(IFormFile file, string filePath, string root);

    }
}
