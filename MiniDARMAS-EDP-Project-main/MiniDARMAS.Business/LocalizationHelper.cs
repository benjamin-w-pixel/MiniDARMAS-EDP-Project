using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MiniDARMAS.Business
{
    public static class LocalizationHelper
    {
        public enum Language
        {
            English,
            Amharic
        }

        public static Language CurrentLanguage { get; set; } = Language.English;

        private static readonly Dictionary<string, string> AmharicTranslations = new Dictionary<string, string>
        {
            // Common
            {"File", "ፋይል"},
            {"Exit", "ውጣ"},
            {"Save", "አስቀምጥ"},
            {"Cancel", "ሰርዝ"},
            {"Delete", "ሰርዝ"},
            {"Logout", "ውጣ"},
            {"Welcome", "እንኳን ደህና መጡ"},
            {"Login", "ግባ"},
            {"Dashboard", "ዳሽቦርድ"},
            {"Language", "ቋንቋ"},
            {"English", "እንግሊዝኛ"},
            {"Amharic", "አማርኛ"},
            {"Refresh", "አድስ"},
            {"Close", "ዝጋ"},
            {"Search:", "ፈልግ:"},
            {"Add New", "አዲስ ጨምር"},
            {"Submit", "ላክ"},
            {"Update", "አዘምን"},
            {"Browse...", "ፈልግ..."},
            {"Select", "ምረጥ"},
            
            // Roles
            {"Admin", "አስተዳዳሪ"},
            {"Operator", "ኦፕሬተር"},
            {"Transcriber", "ጽሑፍ አዘጋጅ"},
            {"Editor", "አርታኢ"},
            {"Approver", "አጽዳቂ"},

            // Status
            {"Assigned", "ተመድቧል"},
            {"In Progress", "በሂደት ላይ"},
            {"Completed", "ተጠናቅቋል"},
            {"Submitted", "ተልኳል"},
            {"Approved", "ጸድቋል"},
            {"Returned", "ተመልሷል"},
            {"Pending", "በጥበቃ ላይ"},

            // Labels
            {"Full Name:", "ሙሉ ስም:"},
            {"Username:", "የተጠቃሚ ስም:"},
            {"Password:", "የይለፍ ቃል:"},
            {"Role:", "ሚና:"},
            {"Is Active", "ንቁ ነው"},
            {"Meeting No:", "የስብሰባ ቁጥር:"},
            {"Title:", "ርዕስ:"},
            {"Date:", "ቀን:"},
            {"Description:", "መግለጫ:"},
            {"Location:", "ቦታ:"},
            {"Status:", "ሁኔታ:"},
            {"Meeting:", "ስብሰባ:"},
            {"Agenda:", "አጀንዳ:"},
            {"Audio File:", "የድምጽ ፋይል:"},
            {"Transcription:", "ጽሑፍ:"},
            {"Remark:", "ማሳሰቢያ:"},
            {"Meeting Date:", "የስብሰባ ቀን:"},
            {"Chairperson:", "ሰብሳቢ:"},
            {"Agenda Title:", "የአጀንዳ ርዕስ:"},
            {"Office:", "ቢሮ:"},
            {"Supporting Document:", "ደጋፊ ሰነድ:"},
            {"Transcriber:", "ጽሑፍ አዘጋጅ:"},
            {"Comments:", "አስተያየቶች:"},

            // Form Headers / GroupBoxes
            {"User Management", "የተጠቃሚ አስተዳደር"},
            {"User Information", "የተጠቃሚ መረጃ"},
            {"Users List", "የተጠቃሚዎች ዝርዝር"},
            {"Meeting Management", "የስብሰባ አስተዳደር"},
            {"Meeting Information", "የስብሰባ መረጃ"},
            {"Meetings List", "የስብሰባዎች ዝርዝር"},
            {"Agenda Management", "የአጀንዳ አስተዳደር"},
            {"Agenda Information", "የአጀንዳ መረጃ"},
            {"Agendas List", "የአጀንዳዎች ዝርዝር"},
            {"Recording Management", "የቅጂ አስተዳደር"},
            {"Recording Information", "የቅጂ መረጃ"},
            {"Recordings List", "የቅጂዎች ዝርዝር"},
            {"Assignment Management", "የምደባ አስተዳደር"},
            {"Assignment Information", "የምደባ መረጃ"},
            {"Assignments List", "የምደባዎች ዝርዝር"},
            {"My Assignments", "የእኔ ምደባዎች"},
            {"Review Transcriptions", "ጽሑፎችን መገምገም"},
            {"Approve Meeting", "ስብሰባ ማጽደቅ"},
            {"Mini-DARMAS Login", "ሚኒ-ዳርማስ መግቢያ"},
            {"Admin Dashboard", "አስተዳዳሪ ዳሽቦርድ"},
            {"System Statistics", "የስርዓት ስታቲስቲክስ"},
            {"Activity Logs (Last 50)", "የእንቅስቃሴ ምዝግብ ማስታወሻዎች"},
            {"Transcription", "ጽሑፍ"},
            {"Review Transcription", "ጽሑፉን ይገምግሙ"},
            {"Submissions Awaiting Review", "የቀረቡ ጽሑፎች (ገና ያልተገመገሙ)"},
            {"Final Meeting Document", "የመጨረሻ የስብሰባ ሰነድ"},
            
            // Specific Buttons / Actions
            {"Add Recording", "ቅጂ ጨምር"},
            {"Play Audio", "ድምጹን አጫውት"},
            {"Stop Audio", "አቁም"},
            {"Save Draft", "ረቂቅ አስቀምጥ"},
            {"Select Audio File", "የድምጽ ፋይል ይምረጡ"},
            {"Total Users:", "ጠቅላላ ተጠቃሚዎች:"},
            {"Total Meetings:", "ጠቅላላ ስብሰባዎች:"},
            {"Pending Assignments:", "የቀሩ ምደባዎች:"},
            {"Submit to Editor", "ለአርታኢ ላክ"},
            {"Approve", "አጽድቅ"},
            {"Return for Correction", "ለማስተካከያ መልስ"},
            {"Export Document", "ሰነዱን ላክ"},
            {"Final Approve Meeting", "ስብሰባውን ለመጨረሻ ጊዜ አጽድቅ"},

            // Form Titles
            {"Transcriber - My Assignments", "ጽሑፍ አዘጋጅ - የእኔ ምደባዎች"},
            {"Editor - Review Transcriptions", "አርታኢ - ጽሑፎችን መገምገም"},
            {"Approver - Final Meeting Approval", "አጽዳቂ - የመጨረሻ የስብሰባ ማጽደቅ"},

            // Messages & Errors
            {"Validation Error", "የማረጋገጫ ስህተት"},
            {"Please enter both username and password.", "እባክዎን የተጠቃሚ ስም እና የይለፍ ቃል ያስገቡ።"},
            {"Access denied. Your role does not match.", "መድረስ ተከልክሏል። ሚናዎ አይዛመድም።"},
            {"Role Mismatch", "የሚና አለመዛመድ"},
            {"Login Failed", "መግባት አልተሳካም"},
            {"Required", "የሚያስፈልግ"},
            {"Found", "የተገኘ"},
            {"Success", "ተሳክቷል"},
            {"Error", "ስህተት"},
            {"Information", "መረጃ"},
            {"Warning", "ማስጠንቀቂያ"},
            {"Are you sure you want to delete this item?", "ይህንን ንጥል ለመሰረዝ እርግጠኛ ነዎት?"},
            {"Operation completed successfully.", "ተግባሩ በተሳካ ሁኔታ ተጠናቅቋል።"},
            {"Login Failed. The username '{0}' or the password you entered is incorrect. Please check your credentials and try again.", "መግባት አልተሳካም። ያስገቡት የተጠቃሚ ስም '{0}' ወይም የይለፍ ቃል የተሳሳተ ነው። እባክዎን መረጃዎን ያረጋግጡና እንደገና ይሞክሩ።"},
            {"Access denied. The account '{0}' exists, but it is assigned the role '{1}', not '{2}'.", "መድረስ ተከልክሏል። '{0}' የሚለው መለያ አለ፣ ነገር ግን የተሰጠው ሚና '{1}' ነው እንጂ '{2}' አይደለም።"}
        };

        public static string GetString(string key, string fallback = "")
        {
            if (string.IsNullOrEmpty(fallback)) fallback = key;

            if (CurrentLanguage == Language.English)
                return fallback;

            if (AmharicTranslations.ContainsKey(key))
                return AmharicTranslations[key];

            return fallback;
        }

        public static void ApplyLanguage(Control parent)
        {
            if (parent == null) return;

            // Translate the parent control itself (e.g., Form title or GroupBox text)
            TranslateControl(parent);

            // Recursively translate all children
            foreach (Control c in parent.Controls)
            {
                ApplyLanguage(c);
            }

            // Special handling for MenuStrip
            if (parent is Form form && form.MainMenuStrip != null)
            {
                foreach (ToolStripItem item in form.MainMenuStrip.Items)
                {
                    TranslateToolStrip(item);
                }
            }

            // Special handling for other types of ToolStrips if present
            foreach (Control c in parent.Controls)
            {
                if (c is ToolStrip ts)
                {
                    foreach (ToolStripItem item in ts.Items)
                    {
                        TranslateToolStrip(item);
                    }
                }
            }
        }

        private static void TranslateControl(Control c)
        {
            if (string.IsNullOrEmpty(c.Text)) return;

            // We use Tag to store the original English text
            if (c.Tag == null || string.IsNullOrEmpty(c.Tag.ToString()))
            {
                // Only store if it's not already translated (this assumes first call is in English)
                // Or if we can find it as a value in AmharicTranslations, it means it's already translated
                bool isAlreadyTranslated = false;
                foreach (var val in AmharicTranslations.Values)
                {
                    if (c.Text == val)
                    {
                        isAlreadyTranslated = true;
                        break;
                    }
                }

                if (!isAlreadyTranslated)
                {
                    c.Tag = c.Text;
                }
                else
                {
                    // If it's already translated, we need to find the original key
                    foreach (var entry in AmharicTranslations)
                    {
                        if (c.Text == entry.Value)
                        {
                            c.Tag = entry.Key;
                            break;
                        }
                    }
                }
            }

            string originalText = c.Tag?.ToString() ?? c.Text;

            if (CurrentLanguage == Language.Amharic)
            {
                if (AmharicTranslations.ContainsKey(originalText))
                {
                    c.Text = AmharicTranslations[originalText];
                }
            }
            else
            {
                c.Text = originalText;
            }

            // Handle ComboBox items if it has predefined strings
            if (c is ComboBox cb)
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    string itemText = cb.Items[i]?.ToString() ?? "";
                    if (AmharicTranslations.ContainsKey(itemText))
                    {
                        // Note: Translating items might break logic if code relies on English names
                        // But LoginForm already handles this for roles.
                        if (CurrentLanguage == Language.Amharic)
                            cb.Items[i] = AmharicTranslations[itemText];
                    }
                    else if (CurrentLanguage == Language.English)
                    {
                        // Try to find the key for this value
                        foreach (var entry in AmharicTranslations)
                        {
                            if (itemText == entry.Value)
                            {
                                cb.Items[i] = entry.Key;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void TranslateToolStrip(ToolStripItem item)
        {
            if (item.Tag == null || string.IsNullOrEmpty(item.Tag.ToString()))
            {
                bool isAlreadyTranslated = false;
                foreach (var val in AmharicTranslations.Values)
                {
                    if (item.Text == val)
                    {
                        isAlreadyTranslated = true;
                        break;
                    }
                }

                if (!isAlreadyTranslated)
                {
                    item.Tag = item.Text;
                }
                else
                {
                    foreach (var entry in AmharicTranslations)
                    {
                        if (item.Text == entry.Value)
                        {
                            item.Tag = entry.Key;
                            break;
                        }
                    }
                }
            }

            string originalText = item.Tag?.ToString() ?? item.Text;

            if (CurrentLanguage == Language.Amharic)
            {
                if (AmharicTranslations.ContainsKey(originalText))
                {
                    item.Text = AmharicTranslations[originalText];
                }
            }
            else
            {
                item.Text = originalText;
            }

            if (item is ToolStripMenuItem menuItem)
            {
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    TranslateToolStrip(subItem);
                }
            }
        }
    }
}
