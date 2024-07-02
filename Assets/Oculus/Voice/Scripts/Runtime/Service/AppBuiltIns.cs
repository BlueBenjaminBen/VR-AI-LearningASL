/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections.Generic;

namespace Oculus.Voice
{
    public static class AppBuiltIns
    {
        public static string builtInPrefix = "builtin:";
        private static string modelName = "Built-in Models";

        public static readonly Dictionary<string, Dictionary<string, string>>
            apps = new Dictionary<string, Dictionary<string, string>>
            {
                {
                    "Chinese", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_zh"},
                        {"name", modelName},
                        {"lang", "zh"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Dutch", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_nl"},
                        {"name", modelName},
                        {"lang", "nl"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "English", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_en"},
                        {"name", modelName},
                        {"lang", "en"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "French", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_fr"},
                        {"name", modelName},
                        {"lang", "fr"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "German", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_de"},
                        {"name", modelName},
                        {"lang", "de"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Italian", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_it"},
                        {"name", modelName},
                        {"lang", "it"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Japanese", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_ja"},
                        {"name", modelName},
                        {"lang", "ja"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Korean", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_ko"},
                        {"name", modelName},
                        {"lang", "ko"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Polish", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_pl"},
                        {"name", modelName},
                        {"lang", "pl"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Portuguese", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_pt"},
                        {"name", modelName},
                        {"lang", "pt"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Russian", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_ru"},
                        {"name", modelName},
                        {"lang", "ru"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Spanish", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_es"},
                        {"name", modelName},
                        {"lang", "es"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Swedish", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_sv"},
                        {"name", modelName},
                        {"lang", "sv"},
                        {"clientToken", "REDACTED"},
                    }
                },
                {
                    "Turkish", new Dictionary<string, string>
                    {
                        {"id", "voiceSDK_tr"},
                        {"name", modelName},
                        {"lang", "tr"},
                        {"clientToken", "REDACTED"},
                    }
                },
            };

        public static string[] appNames
        {
            get
            {
                string[] keys = new string[apps.Keys.Count];
                apps.Keys.CopyTo(keys, 0);
                return keys;
            }
        }
    }
}
