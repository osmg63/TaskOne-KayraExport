﻿using Newtonsoft.Json;

namespace TaskOneKayraExport.Exceptions
{
    public class ExceptionModel: ErrorStatusCode
    {
        public IEnumerable<string> Errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
