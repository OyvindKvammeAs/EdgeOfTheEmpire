using EdgeOfTheEmpire.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdgeOfTheEmpire.Services
{
    public class StaticDataRepository : IStaticDataRepository
    {
        private readonly IList<Career> careers;
        private readonly IList<Skill> skills;
        private readonly IList<Talent> talents;
        private readonly IList<Specialization> specializations;
        private readonly IDictionary<Career, IList<Skill>> careerSkills;
        private readonly IDictionary<Specialization, IList<Skill>> specializationSkills;
        private readonly IList<TalentTree> talentTrees;
        

        public StaticDataRepository()
        {
            careers = CreateCareers();
            skills = CreateSkills();
            talents = CreateTalents();
            specializations = CreateSpecializations();
            careerSkills = CreateCareerSkills();
            specializationSkills = CreateSpecializationSkills();            
            talentTrees = CreateTalentTrees();
        }

        private IList<Career> CreateCareers()
        {
            return new List<Career>()
            {
                new Career(1, "Bounty Hunter"),
                new Career(2, "Colonist"),
                new Career(3, "Explorer"),
                new Career(4, "Hired Gun"),
                new Career(5, "Smuggler"),
                new Career(6, "Technician"),
                new Career(7, "Ace"),
                new Career(8, "Commander"),
                new Career(9, "Diplomat"),
                new Career(10, "Engineer"),
                new Career(11, "Soldier"),
                new Career(12, "Spy"),
                new Career(13, "Consular"),
                new Career(14, "Guardian"),
                new Career(15, "Mystic"),
                new Career(16, "Seeker"),
                new Career(17, "Sentinel"),
                new Career(18, "Warrior"),
                new Career(19, "Universal")
            };
        }

        public Career GetCareer(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new System.Exception("No career found");
            return careers.First<Career>(x => x.CareerName.Equals(name));
        }

        public Skill GetSkill(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new System.Exception("No skill found");
            return skills.First<Skill>(x => x.Name.Equals(name));
        }

        public IList<Career> GetCareersWithSkill(Skill skill)
        {
            IList<Career> result = new List<Career>();
            var careers = GetCarreers();
            foreach (var career in careers)
            {
               var skills = GetCareerSkills(career);
                if (skills.Contains(skill))
                {
                    result.Add(career);
                }
            }

            return result;
        }
        public IList<Specialization> GetSpecializationsWithSkill(Skill skill)
        {
            IList<Specialization> result = new List<Specialization>();
            var specializations = GetSpecializations();
            foreach (var specialization in specializations)
            {
                var skills = GetSpecializationSkills(specialization);
                if (skills.Contains(skill))
                {
                    result.Add(specialization);
                }
            }

            return result;
        }

        private IList<Skill> CreateSkills()
        {
            return new List<Skill>()
            {
                new Skill(1, "Astrogation", "", Attribute.Intelligence, SkillCategory.General),
                new Skill(2, "Athletics", "", Attribute.Brawn, SkillCategory.General),
                new Skill(3, "Charm", "", Attribute.Presence, SkillCategory.General),
                new Skill(4, "Coercion", "", Attribute.Willpower, SkillCategory.General),
                new Skill(5, "Computers", "", Attribute.Intelligence, SkillCategory.General),
                new Skill(6, "Cool", "", Attribute.Presence, SkillCategory.General),
                new Skill(7, "Coordination", "", Attribute.Agility, SkillCategory.General),
                new Skill(8, "Deception", "", Attribute.Cunning, SkillCategory.General),
                new Skill(9, "Discipline", "", Attribute.Willpower, SkillCategory.General),
                new Skill(10, "Leadership", "", Attribute.Presence, SkillCategory.General),
                new Skill(11, "Mechanics", "", Attribute.Intelligence, SkillCategory.General),
                new Skill(12, "Medicine", "", Attribute.Intelligence, SkillCategory.General),
                new Skill(13, "Negotiation", "", Attribute.Presence, SkillCategory.General),
                new Skill(14, "Perception", "", Attribute.Cunning, SkillCategory.General),
                new Skill(15, "Piloting Planetary", "", Attribute.Agility, SkillCategory.General),
                new Skill(16, "Piloting Space", "", Attribute.Agility, SkillCategory.General),
                new Skill(17, "Resilience", "", Attribute.Brawn, SkillCategory.General),
                new Skill(18, "Skulduggery", "", Attribute.Cunning, SkillCategory.General),
                new Skill(19, "Stealth", "", Attribute.Agility, SkillCategory.General),
                new Skill(20, "Streetwise", "", Attribute.Cunning, SkillCategory.General),
                new Skill(21, "Survival", "", Attribute.Cunning, SkillCategory.General),
                new Skill(22, "Vigilance", "", Attribute.Willpower, SkillCategory.General),
                new Skill(23, "Brawl", "", Attribute.Brawn, SkillCategory.Combat),
                new Skill(24, "Gunnery", "", Attribute.Agility, SkillCategory.Combat),
                new Skill(25, "Lightsaber", "", Attribute.Brawn, SkillCategory.Combat),
                new Skill(26, "Melee", "", Attribute.Brawn, SkillCategory.Combat),
                new Skill(27, "Ranged Heavy", "", Attribute.Agility, SkillCategory.Combat),
                new Skill(28, "Ranged Light", "", Attribute.Agility, SkillCategory.Combat),
                new Skill(29, "Core Worlds", "", Attribute.Intelligence, SkillCategory.Knowledge),
                new Skill(30, "Education", "", Attribute.Intelligence, SkillCategory.Knowledge),
                new Skill(31, "Lore", "", Attribute.Intelligence, SkillCategory.Knowledge),
                new Skill(32, "Outer Rim", "", Attribute.Intelligence, SkillCategory.Knowledge),
                new Skill(33, "Underworld", "", Attribute.Intelligence, SkillCategory.Knowledge),
                new Skill(34, "Warfare", "", Attribute.Intelligence, SkillCategory.Knowledge),
                new Skill(35, "Xenology", "", Attribute.Intelligence, SkillCategory.Knowledge)
            };
        }

        private IList<Talent> CreateTalents()
        {
            return new List<Talent>()
            {
                new Talent("Adversary",false,true,false),
                new Talent("Against all Odds",true,false,true),
                new Talent("Aggressive Negotiations",true,false,true),
                new Talent("All-Terrain Driver",false,false,false),
                new Talent("Ambush",true,false,false),                
                new Talent("Anatomy Lessons",true,false,false),
                new Talent("Animal Bond",false,false,true),
                new Talent("Animal Bond (Improved)",false,false,true),
                new Talent("Animal Empathy",false,false,true),
                new Talent("Armor Master",false,false,false),
                new Talent("Armor Master (Supreme)",true,false,false),
                new Talent("Armor Master [Improved]",false,false,false),
                new Talent("Ataru Technique",false,false,true),
                new Talent("Bacta Specialist",false,true,false),
                new Talent("Bad Cop",false,true,false),
                new Talent("Bad Motivator",true,false,false),
                new Talent("Bad Press",true,false,false),
                new Talent("Balance",true,false,true),
                new Talent("Baleful Gaze",true,false,true),
                new Talent("Barrage",false,true,false),
                new Talent("Basic Combat Training",false,false,false),
                new Talent("Beast Wrangler",false,true,false),
                new Talent("Better Luck Next Time",true,false,false),
                new Talent("Biggest Fan",true,false,false),
                new Talent("Black Market Contacts",true,true,false),
                new Talent("Blackmail",true,false,false),
                new Talent("Blind Spot",false,false,false),
                new Talent("Blooded",false,true,false),
                new Talent("Body Guard",true,true,false),
                new Talent("Body Guard (Improved)",true,false,false),
                new Talent("Body Guard (Supreme)",false,false,false),
                new Talent("Bolstered Armor",false,true,false),
                new Talent("Bought Info",true,false,false),
                new Talent("Brace",true,true,false),
                new Talent("Brilliant Evasion",true,false,false),
                new Talent("Bring it Down",true,false,false),
                new Talent("Burly",false,true,false),
                new Talent("Bypass Security",false,true,false),
                new Talent("Call 'em",false,false,false),
                new Talent("Calm Commander",false,false,false),
                new Talent("Calming Aura",false,false,true),
                new Talent("Calming Aura (Improved)",true,false,true),
                new Talent("Careful Planning",true,false,false),
                new Talent("Center of Being",true,true,true),
                new Talent("Center of Being (Improved)",false,false,true),
                new Talent("Circle of Shelter",false,false,true),
                new Talent("Clever Commander",false,false,false),
                new Talent("Clever Solution",true,false,false),
                new Talent("Codebreaker",false,true,false),
                new Talent("Command",false,true,false),
                new Talent("Commanding Presence",false,true,false),
                new Talent("Commanding Presence (Improved)",true,false,false),
                new Talent("Comprehend Technology",true,false,true),
                new Talent("Conditioned",false,true,false),
                new Talent("Confidence",false,true,false),
                new Talent("Confidence (Improved)",false,false,false),
                new Talent("Congenial",true,true,false),
                new Talent("Constant Vigilance",false,false,false),
                new Talent("Contingency Plan",true,false,false),
                new Talent("Contraption",true,false,false),
                new Talent("Convincing Demeanor",false,true,false),
                new Talent("Coordinated Assault",true,true,false),
                new Talent("Coordination Dodge",true,false,false),
                new Talent("Corellian Sendoff",true,false,false),
                new Talent("Corellian Sendoff [Improved]",false,false,false),
                new Talent("Counterstrike",false,false,true),
                new Talent("Creative Killer",false,false,false),
                new Talent("Crippling Blow",true,false,false),
                new Talent("Crucial Point",true,true,false),
                new Talent("Cunning Snare",true,false,false),
                new Talent("Custom Loadout",false,false,false),
                new Talent("Customized Cooling Unit",false,true,false),
                new Talent("Cutting Question",true,false,false),
                new Talent("Cyberneticist",false,true,false),
                new Talent("Dead to Rights",true,false,false),
                new Talent("Dead to Rights [Improved]",true,false,false),
                new Talent("Deadly Accuracy",false,true,false),
                new Talent("Deathblow",false,false,false),
                new Talent("Debilitating Shot",true,false,false),
                new Talent("Deceptive Taunt",true,false,false),
                new Talent("Dedication",false,true,false),
                new Talent("Defensive Circle",true,false,true),
                new Talent("Defensive Driving",false,true,false),
                new Talent("Defensive Slicing",false,true,false),
                new Talent("Defensive Slicing [Improved]",false,false,false),
                new Talent("Defensive Stance",true,true,false),
                new Talent("Defensive Training",false,true,false),
                new Talent("Deft Maker",false,true,false),
                new Talent("Disarming Smile",true,true,false),
                new Talent("Discredit",true,false,false),
                new Talent("Disorient",false,true,false),
                new Talent("Disruptive Strike",true,false,true),
                new Talent("Distracting Behavior",true,true,false),
                new Talent("Distracting Behavior (Improved)",false,false,false),
                new Talent("Djem So Deflection",true,false,true),
                new Talent("Dodge",true,true,false),
                new Talent("Don't Shoot",true,false,false),
                new Talent("Double or Nothing",true,false,false),
                new Talent("Double or Nothing (Improved)",false,false,false),
                new Talent("Double or Nothing (Supreme)",false,false,false),
                new Talent("Draw Closer",true,false,true),
                new Talent("Drive Back",false,false,true),
                new Talent("Duelist's Training",false,false,false),
                new Talent("Durable",false,true,false),
                new Talent("Dynamic Fire",true,false,false),
                new Talent("Empty Soul",false,false,true),
                new Talent("Encoded Communique",false,false,false),
                new Talent("Encouraging Words",true,false,false),
                new Talent("Enduring",false,true,false),
                new Talent("Energy Transfer",true,false,false),
                new Talent("Engineered Redundancies",false,false,false),
                new Talent("Enhanced Leader",false,false,true),
                new Talent("Essential Kill",false,false,true),
                new Talent("Exaust Port",true,false,false),
                new Talent("Exhaust Port",true,false,false),
                new Talent("Expert Handler",false,true,false),
                new Talent("Expert Tracker",false,true,false),
                new Talent("Eye for Detail",true,true,false),
                new Talent("Falling Avalanche",true,false,true),
                new Talent("Familiar Suns",true,false,false),
                new Talent("Fancy Paint Job",false,false,false),
                new Talent("Fear the Shadows",true,false,true),
                new Talent("Fearsome",false,true,false),
                new Talent("Feint",false,true,false),
                new Talent("Feral Strength",false,true,false),
                new Talent("Field Commander",true,false,false),
                new Talent("Field Commander [Improved]",false,false,false),
                new Talent("Fine Tuning",false,true,false),
                new Talent("Fire Control",false,true,false),
                new Talent("Forager",false,false,false),
                new Talent("Force Assault",false,false,true),
                new Talent("Force Connection",false,false,true),
                new Talent("Force of Will",true,false,false),
                new Talent("Force Protection",true,true,true),
                new Talent("Force Rating",false,true,true),
                new Talent("Forewarning",true,false,true),
                new Talent("Form on Me",false,false,false),
                new Talent("Fortified Vacuum Seal",false,true,false),
                new Talent("Fortune Favors the Bold",true,false,false),
                new Talent("Freerunning",true,false,false),
                new Talent("Freerunning (Improved)",true,false,false),
                new Talent("Frenzied Attack",true,true,false),
                new Talent("Full Stop",true,false,false),
                new Talent("Full Throttle",true,false,false),
                new Talent("Full Throttle [Improved]",true,false,false),
                new Talent("Full Throttle [Supreme]",false,false,false),
                new Talent("Galaxy Mapper",false,true,false),
                new Talent("Gang Leader",true,false,false),
                new Talent("Gearhead",false,true,false),
                new Talent("Go Without",true,false,false),
                new Talent("Good Cop",false,true,false),
                new Talent("Grapple",true,false,false),
                new Talent("Greased Palms",true,false,false),
                new Talent("Grit",false,true,false),
                new Talent("Guns Blazing",true,false,false),
                new Talent("Harass",true,false,false),
                new Talent("Hard Headed",true,true,false),
                new Talent("Hard Headed [Improved]",true,false,false),
                new Talent("Hard-Boiled",false,true,false),
                new Talent("Hawk Bat Swoop",true,false,true),
                new Talent("Healing Trance",true,true,true),
                new Talent("Healing Trance (Improved)",false,false,true),
                new Talent("Heavy Hitter",true,false,false),
                new Talent("Heightened Awareness",false,false,false),
                new Talent("Heroic Fortitude",true,false,false),
                new Talent("Heroic Resilience",true,false,false),
                new Talent("Hidden Storage",false,true,false),
                new Talent("High-G Training",true,true,false),
                new Talent("Hindering Shot",true,false,false),
                new Talent("Hold Together",true,false,false),
                new Talent("Holistic Navigation",true,false,true),
                new Talent("Hunter",false,true,false),
                new Talent("Hunter's Quarry",true,false,false),
                new Talent("Hunter's Quarry [Improved]",false,false,false),
                new Talent("Idealist",true,true,false),
                new Talent("Imbue Item",true,false,true),
                new Talent("Impossible Fall",true,false,true),
                new Talent("Improvised Detonation",true,false,false),
                new Talent("Improvised Detonation [Improved]",false,false,false),
                new Talent("In the Know",false,true,false),
                new Talent("In the Know (Improved)",true,false,false),
                new Talent("Incite Rebellion",true,false,false),
                new Talent("Indistinguishable",false,true,false),
                new Talent("Informant",true,false,false),
                new Talent("Inity Assault",true,false,true),
                new Talent("Insight",false,false,true),
                new Talent("Inspiring Rhetoric",true,false,false),
                new Talent("Inspiring Rhetoric [Improved]",false,false,false),
                new Talent("Inspiring Rhetoric [Supreme]",true,false,false),
                new Talent("Intense Focus",true,false,false),
                new Talent("Intense Presence",true,false,false),
                new Talent("Interjection",true,false,false),
                new Talent("Intimidating",true,true,false),
                new Talent("Intuitive Evasion",true,true,true),
                new Talent("Intuitive Improvements",false,false,true),
                new Talent("Intuitive Navigation",false,false,true),
                new Talent("Intuitive Shot",false,false,true),
                new Talent("Intuitive Strike",false,false,true),
                new Talent("Inventor",false,true,false),
                new Talent("Invigorate",true,false,true),
                new Talent("Iron Body",false,true,false),
                new Talent("Iron Soul",false,false,false),
                new Talent("It's Not That Bad",true,false,false),
                new Talent("Jump Up",true,false,false),
                new Talent("Jury Rigged",false,true,false),
                new Talent("Just Kidding!",true,false,false),
                new Talent("Keen Eyed",false,true,false),
                new Talent("Kill with Kindness",false,true,false),
                new Talent("Knockdown",false,false,false),
                new Talent("Know-It-All",true,false,false),
                new Talent("Know Somebody",true,true,false),
                new Talent("Knowledge is Power",true,false,true),
                new Talent("Knowledge Specialization",false,true,false),
                new Talent("Knowledgeable Healing",false,false,false),
                new Talent("Known Schematic",true,false,false),
                new Talent("Koiogran Turn",true,false,false),
                new Talent("Larger Project",false,true,false),
                new Talent("Let's Ride",true,false,false),
                new Talent("Lethal Blows",false,true,false),
                new Talent("Lightsaber Mastery",false,false,true),
                new Talent("Loom",false,false,false),
                new Talent("Machine Mender",false,true,false),
                new Talent("Makashi Finish",true,false,true),
                new Talent("Makashi Flourish",true,false,true),
                new Talent("Makashi Technique",true,false,true),
                new Talent("Marked for Death",true,false,true),
                new Talent("Martial Grace",true,false,false),
                new Talent("Master Artisan",true,false,false),
                new Talent("Master Doctor",true,false,false),
                new Talent("Master Driver",true,false,false),
                new Talent("Master Grenadier",false,false,false),
                new Talent("Master Instructor",true,false,false),
                new Talent("Master Leader",true,false,false),
                new Talent("Master Merchant",true,false,false),
                new Talent("Master of Shadows",true,false,false),
                new Talent("Master Pilot",true,false,false),
                new Talent("Master Slicer",true,false,false),
                new Talent("Master Starhopper",true,false,false),
                new Talent("Master Strategist",true,false,false),
                new Talent("Meditative Trance",false,false,true),
                new Talent("Menace",true,false,false),
                new Talent("Mental Bond",true,false,true),
                new Talent("Mental Fortress",true,false,false),
                new Talent("Mental Tools",false,false,true),
                new Talent("Mind Bleed",true,false,true),
                new Talent("Mind Over Matter",true,false,false),
                new Talent("More Machine than Man",false,true,false),
                new Talent("Moving Target",false,true,false),
                new Talent("Multiple Opponents",false,false,false),
                new Talent("Museum Worthy",true,false,false),
                new Talent("Natural Athlete",true,false,false),
                new Talent("Natural Blademaster",true,false,false),
                new Talent("Natural Brawler",true,false,false),
                new Talent("Natural Charmer",true,false,false),
                new Talent("Natural Doctor",true,false,false),
                new Talent("Natural Driver",true,false,false),
                new Talent("Natural Enforcer",true,false,false),
                new Talent("Natural Hunter",true,false,false),
                new Talent("Natural Instructor",true,false,false),
                new Talent("Natural Leader",true,false,false),
                new Talent("Natural Marksman",true,false,false),
                new Talent("Natural Merchant",true,false,false),
                new Talent("Natural Mystic",true,false,false),
                new Talent("Natural Negotiator",true,false,false),
                new Talent("Natural Outdoorsman",true,false,false),
                new Talent("Natural Pilot",true,false,false),
                new Talent("Natural Programmer",true,false,false),
                new Talent("Natural Rogue",true,false,false),
                new Talent("Natural Scholar",true,false,false),
                new Talent("Natural Tinkerer",true,false,false),
                new Talent("Niman Technique",false,false,true),
                new Talent("No Escape",false,false,true),
                new Talent("Nobody's Fool",false,true,false),
                new Talent("Not Today",true,false,false),
                new Talent("Now The Master",true,false,false),
                new Talent("Now You See Me",true,false,true),
                new Talent("Offensive Driving",true,false,false),
                new Talent("Once A Learner",true,false,true),
                new Talent("One with Nature",false,false,false),
                new Talent("One With the Universe",true,false,true),
                new Talent("Outdoorsman",false,true,false),
                new Talent("Overbalance",false,false,false),
                new Talent("Overcharge",true,false,false),
                new Talent("Overcharge (Improved)",false,false,false),
                new Talent("Overcharge (Supreme)",true,false,false),
                new Talent("Overstocked Ammo",false,true,false),
                new Talent("Overwhelm Defenses",true,true,false),
                new Talent("Overwhelm Emotions",false,false,true),
                new Talent("Parry",true,true,false),
                new Talent("Parry (Improved)",true,false,false),
                new Talent("Parry (Supreme)",false,false,true),
                new Talent("Physical Training",false,true,false),
                new Talent("Physician",false,true,false),
                new Talent("Pin",true,false,false),
                new Talent("Planet Mapper",false,true,false),
                new Talent("Plausible Deniability",false,true,false),
                new Talent("Plausible Deniability (Improved)",true,false,false),
                new Talent("Point Blank",false,true,false),
                new Talent("Positive Spin",false,true,false),
                new Talent("Positive Spin (Improved)",true,false,false),
                new Talent("Powerful Blast",false,true,false),
                new Talent("Precise Aim",true,true,false),
                new Talent("Precision Strike",true,false,false),
                new Talent("Precision Strike (Improved)",true,false,false),
                new Talent("Precision Strike (Supreme)",true,false,false),
                new Talent("Preemptive Avoidance",true,false,true),
                new Talent("Prescient Shot",false,false,true),
                new Talent("Pressure Point",true,false,false),
                new Talent("Prey on the Weak",false,true,false),
                new Talent("Prime Positions",false,true,false),
                new Talent("Prophetic Aim",false,false,true),
                new Talent("Quick Draw",true,false,false),
                new Talent("Quick Draw (Improved)",false,false,false),
                new Talent("Quick Fix",true,false,false),
                new Talent("Quick Movement",true,false,true),
                new Talent("Quick Strike",false,true,false),
                new Talent("Rain of Death",true,false,false),
                new Talent("Rapid Reaction",true,true,false),
                new Talent("Rapid Recovery",false,true,false),
                new Talent("Ready for Anything",false,true,false),
                new Talent("Ready for Anything [Improved]",false,true,false),
                new Talent("Reconstruct the Scene",true,false,false),
                new Talent("Redundant Systems",true,false,false),
                new Talent("Reflect",true,true,true),
                new Talent("Reflect (Improved)",true,false,true),
                new Talent("Reflect (Supreme)",false,false,true),
                new Talent("Reinforce Item",true,false,true),
                new Talent("Reinforced Frame",false,false,false),
                new Talent("Reroute Processors",true,false,false),
                new Talent("Researcher",false,true,false),
                new Talent("Researcher (Improved)",false,false,false),
                new Talent("Resist Disarm",true,false,false),
                new Talent("Resolve",false,true,false),
                new Talent("Resourceful Refit",true,false,false),
                new Talent("Respected Scholar",false,true,false),
                new Talent("Ritual Caster",true,false,true),
                new Talent("Saber Swarm",true,false,true),
                new Talent("Saber Throw",true,false,true),
                new Talent("Saber Throw (Improved)",false,false,true),
                new Talent("Sarlacc Sweep",true,false,true),
                new Talent("Savvy Negotiator",false,true,false),
                new Talent("Savvy Negotiator (Improved)",true,false,false),
                new Talent("Scathing Tirade",true,false,false),
                new Talent("Scathing Tirade [Improved]",false,false,false),
                new Talent("Scathing Tirade [Supreme]",true,false,false),
                new Talent("Second Chances",true,true,false),
                new Talent("Second Wind",true,true,false),
                new Talent("Seize the Initiative",true,false,false),
                new Talent("Selective Detonation",true,true,false),
                new Talent("Sense Advantage",true,false,true),
                new Talent("Sense Danger",true,false,true),
                new Talent("Sense Emotions",false,false,true),
                new Talent("Sense the Scene",true,false,true),
                new Talent("Share Pain",true,false,true),
                new Talent("Shien Technique",false,false,true),
                new Talent("Shortcut",false,true,false),
                new Talent("Shortcut (Improved)",false,false,false),
                new Talent("Shroud", true, false, true),
                new Talent("Showboat",true,false,false),
                new Talent("Side Step",true,true,false),
                new Talent("Signature Vehicle",false,false,false),
                new Talent("Situational Awareness",false,false,false),
                new Talent("Sixth Sense",false,false,false),
                new Talent("Skilled Jockey",false,true,false),
                new Talent("Skilled Slicer",true,false,false),
                new Talent("Skilled Teacher",true,true,false),
                new Talent("Sleight of Mind",false,false,true),
                new Talent("Slippery Minded",true,false,true),
                new Talent("Smooth Talker",true,true,false),
                new Talent("Sniper Shot",true,true,false),
                new Talent("Soft Spot",true,false,false),
                new Talent("Solid Repairs",false,true,false),
                new Talent("Soothing Tone",true,false,false),
                new Talent("Soresu Technique",false,false,true),
                new Talent("Sorry About the Mess",false,false,false),
                new Talent("Sound Investments",false,true,false),
                new Talent("Spare Clip",false,false,false),
                new Talent("Speaks Binary",false,true,false),
                new Talent("Speaks Binary (Improved)",false,false,false),
                new Talent("Speaks Binary (Supreme)",true,false,false),
                new Talent("Spitfire",false,false,false),
                new Talent("Spur",true,false,false),
                new Talent("Spur [Improved]",true,false,false),
                new Talent("Spur [Supreme]",false,false,false),
                new Talent("Stalker",false,true,false),
                new Talent("Steady Nerves",false,true,false),
                new Talent("Steely Nerves",true,false,false),
                new Talent("Stim Application",true,false,false),
                new Talent("Stim Application [Improved]",true,false,false),
                new Talent("Stim Application [Supreme]",false,false,false),
                new Talent("Stimpack Specialization",false,true,false),
                new Talent("Strategic Form",true,false,true),
                new Talent("Street Smarts",false,true,false),
                new Talent("Street Smarts (Improved)",true,false,false),
                new Talent("Stroke of Genius",true,false,false),
                new Talent("Strong Arm",false,false,false),
                new Talent("Studious Plotting",false,false,false),
                new Talent("Stunning Blow",true,false,false),
                new Talent("Stunning Blow [Improved]",true,false,false),
                new Talent("Sum Djem",false,false,true),
                new Talent("Sunder (Improved)",false,false,false),
                new Talent("Superhuman Reflexes",true,false,true),
                new Talent("Superior Reflexes",false,false,false),
                new Talent("Supporting Evidence",false,true,false),
                new Talent("Suppressing Fire",false,true,false),
                new Talent("Surgeon",false,true,false),
                new Talent("Survival of the Fittest",true,false,true),
                new Talent("Swift",false,false,false),
                new Talent("Tactical Combat Training",false,false,false),
                new Talent("Talk the Talk",true,false,false),
                new Talent("Targeted Blow",true,false,false),
                new Talent("Technical Aptitude",false,true,false),
                new Talent("Terrify",true,false,true),
                new Talent("Terrify (Improved)",false,false,true),
                new Talent("Terrifying Kill",true,false,true),
                new Talent("That's how it's Done",true,true,false),
                new Talent("The Force is my Ally",true,false,true),
                new Talent("Thorough Assessment",true,false,false),
                new Talent("Throwing Credits",true,false,false),
                new Talent("Time to Go",true,false,false),
                new Talent("Time to Go [Improved]",true,false,false),
                new Talent("Tinkerer",false,true,false),
                new Talent("Touch of Fate",true,false,true),
                new Talent("Toughened",false,true,false),
                new Talent("Tricky Target",false,false,false),
                new Talent("True Aim",true,true,false),
                new Talent("Tuned Maneuvering Thrusters",false,true,false),
                new Talent("Twisted Words",true,false,false),
                new Talent("Unarmed Parry",false,false,false),
                new Talent("Uncanny Reactions",false,true,true),
                new Talent("Uncanny Senses",false,true,true),
                new Talent("Unrelenting Skeptic",false,false,false),
                new Talent("Unrelenting Skeptic (Improved)",true,false,false),
                new Talent("Unity Assault", true, false, true),
                new Talent("Unstoppable",false,false,false),
                new Talent("Up the Ante",false,true,false),
                new Talent("Utility Belt",true,false,false),
                new Talent("Utinni!",false,true,false),
                new Talent("Valuable Facts",true,false,false),
                new Talent("Vehicle Combat Training",false,false,false),
                new Talent("Walk the Walk",true,false,false),
                new Talent("Well Read",false,true,false),
                new Talent("Well Rounded",false,true,false),
                new Talent("Well Traveled",false,false,false),
                new Talent("Wheel and Deal",false,true,false),
                new Talent("Wise Warrior",true,false,false),
                new Talent("Wise Warrior (Improved)",true,false,false),
                new Talent("Works Like a Charm",true,false,false)
            };
        }


        private IList<Specialization> CreateSpecializations()
        {
            return new List<Specialization>()
            {
                new Specialization(1, "Assassin", GetCareer("Bounty Hunter")),
                new Specialization(2, "Gadgeteer", GetCareer("Bounty Hunter")),
                new Specialization(3, "Martial Artist", GetCareer("Bounty Hunter")),
                new Specialization(4, "Operator", GetCareer("Bounty Hunter")),
                new Specialization(5, "Skip Tracer", GetCareer("Bounty Hunter")),
                new Specialization(6, "Survivalist", GetCareer("Bounty Hunter")),

                new Specialization(7, "Doctor", GetCareer("Colonist")),
                new Specialization(8, "Entrepreneur", GetCareer("Colonist")),
                new Specialization(9, "Marshal", GetCareer("Colonist")),
                new Specialization(10, "Performer", GetCareer("Colonist")),
                new Specialization(11, "Politico", GetCareer("Colonist")),
                new Specialization(12, "Scholar", GetCareer("Colonist")),

                new Specialization(13, "Archaeologist", GetCareer("Explorer")),
                new Specialization(14, "Big-Game Hunter", GetCareer("Explorer")),
                new Specialization(15, "Driver", GetCareer("Explorer")),
                new Specialization(16, "Fringer", GetCareer("Explorer")),
                new Specialization(17, "Scout", GetCareer("Explorer")),
                new Specialization(18, "Trader", GetCareer("Explorer")),

                new Specialization(19, "Bodyguard", GetCareer("Hired Gun")),
                new Specialization(20, "Demolitionist", GetCareer("Hired Gun")),
                new Specialization(21, "Enforcer", GetCareer("Hired Gun")),
                new Specialization(22, "Heavy", GetCareer("Hired Gun")),
                new Specialization(23, "Marauder", GetCareer("Hired Gun")),
                new Specialization(24, "Mercenary Soldier", GetCareer("Hired Gun")),

                new Specialization(25, "Charmer", GetCareer("Smuggler")),
                new Specialization(26, "Gambler", GetCareer("Smuggler")),
                new Specialization(27, "Gunslinger", GetCareer("Smuggler")),
                new Specialization(28, "Pilot", GetCareer("Smuggler")),
                new Specialization(29, "Scoundrel", GetCareer("Smuggler")),
                new Specialization(30, "Thief", GetCareer("Smuggler")),

                new Specialization(31, "Cyber Tech", GetCareer("Technician")),
                new Specialization(32, "Droid Tech", GetCareer("Technician")),
                new Specialization(33, "Mechanic", GetCareer("Technician")),
                new Specialization(34, "Modder", GetCareer("Technician")),
                new Specialization(35, "Outlaw Tech", GetCareer("Technician")),
                new Specialization(36, "Slicer", GetCareer("Technician")),

                new Specialization(37, "Beast Rider", GetCareer("Ace")),
                new Specialization(38, "Driver Ace", GetCareer("Ace")),
                new Specialization(39, "Gunner", GetCareer("Ace")),
                new Specialization(40, "Hotshot", GetCareer("Ace")),
                new Specialization(41, "Pilot Ace", GetCareer("Ace")),
                new Specialization(42, "Rigger", GetCareer("Ace")),

                new Specialization(43, "Commodore", GetCareer("Commander")),
                new Specialization(44, "Figurehead", GetCareer("Commander")),
                new Specialization(45, "Instructor", GetCareer("Commander")),
                new Specialization(46, "Squadron Leader", GetCareer("Commander")),
                new Specialization(47, "Strategist", GetCareer("Commander")),
                new Specialization(48, "Tactician", GetCareer("Commander")),

                new Specialization(49, "Advocate", GetCareer("Diplomat")),
                new Specialization(50, "Agitator", GetCareer("Diplomat")),
                new Specialization(51, "Ambassador", GetCareer("Diplomat")),
                new Specialization(52, "Analyst", GetCareer("Diplomat")),
                new Specialization(53, "Propagandist", GetCareer("Diplomat")),
                new Specialization(54, "Quartermaster", GetCareer("Diplomat")),

                new Specialization(55, "Mechanic Engineer", GetCareer("Engineer")),
                new Specialization(56, "Saboteur", GetCareer("Engineer")),
                new Specialization(57, "Scientist", GetCareer("Engineer")),
                new Specialization(58, "eng1", GetCareer("Engineer")),
                new Specialization(59, "eng2", GetCareer("Engineer")),
                new Specialization(60, "eng3", GetCareer("Engineer")),

                new Specialization(61, "Commando", GetCareer("Soldier")),
                new Specialization(62, "Heavy Soldier", GetCareer("Soldier")),
                new Specialization(63, "Medic", GetCareer("Soldier")),
                new Specialization(64, "Sharpshooter", GetCareer("Soldier")),
                new Specialization(65, "Trailblazer", GetCareer("Soldier")),
                new Specialization(66, "Vanguard", GetCareer("Soldier")),

                new Specialization(67, "Infiltrator", GetCareer("Spy")),
                new Specialization(68, "Scout Spy", GetCareer("Spy")),
                new Specialization(69, "Slicer Spy", GetCareer("Spy")),
                new Specialization(70, "spy1", GetCareer("Spy")),
                new Specialization(71, "spy2", GetCareer("Spy")),
                new Specialization(72, "spy3", GetCareer("Spy")),

                new Specialization(73, "Healer", GetCareer("Consular")),
                new Specialization(74, "Niman Disciple", GetCareer("Consular")),
                new Specialization(75, "Sage", GetCareer("Consular")),
                new Specialization(76, "con1", GetCareer("Consular")),
                new Specialization(77, "con2", GetCareer("Consular")),
                new Specialization(78, "con3", GetCareer("Consular")),

                new Specialization(79, "Armorer", GetCareer("Guardian")),
                new Specialization(80, "Peacekeeper", GetCareer("Guardian")),
                new Specialization(81, "Protector", GetCareer("Guardian")),
                new Specialization(82, "Soresu Defender", GetCareer("Guardian")),
                new Specialization(83, "Warden", GetCareer("Guardian")),
                new Specialization(84, "Warleader", GetCareer("Guardian")),

                new Specialization(85, "Advisor", GetCareer("Mystic")),
                new Specialization(86, "Makashi Duelist", GetCareer("Mystic")),
                new Specialization(87, "Seer", GetCareer("Mystic")),
                new Specialization(88, "mys1", GetCareer("Mystic")),
                new Specialization(89, "mys2", GetCareer("Mystic")),
                new Specialization(90, "mys3", GetCareer("Mystic")),

                new Specialization(91, "Ataru Striker", GetCareer("Seeker")),
                new Specialization(92, "Executioner", GetCareer("Seeker")),
                new Specialization(93, "Hermit", GetCareer("Seeker")),
                new Specialization(94, "Hunter", GetCareer("Seeker")),
                new Specialization(95, "Navigator", GetCareer("Seeker")),
                new Specialization(96, "Pathfinder", GetCareer("Seeker")),

                new Specialization(97, "Artisan", GetCareer("Sentinel")),
                new Specialization(98, "Investigator", GetCareer("Sentinel")),
                new Specialization(99, "Racer", GetCareer("Sentinel")),
                new Specialization(100, "Sentry", GetCareer("Sentinel")),
                new Specialization(101, "Shadow", GetCareer("Sentinel")),
                new Specialization(102, "Shien Expert", GetCareer("Sentinel")),

                new Specialization(103, "Aggressor", GetCareer("Warrior")),
                new Specialization(104, "Shii-Cho Knight", GetCareer("Warrior")),
                new Specialization(105, "Starfighter Ace", GetCareer("Warrior")),
                new Specialization(106, "war1", GetCareer("Warrior")),
                new Specialization(107, "war2", GetCareer("Warrior")),
                new Specialization(108, "war3", GetCareer("Warrior")),

                new Specialization(109, "Force-Sensitive Exile", GetCareer("Universal")),
                new Specialization(110, "Force-Sensitive Emergent", GetCareer("Universal")),
                new Specialization(111, "Recruit", GetCareer("Universal"))
            };
        }
        private IDictionary<Career, IList<Skill>> CreateCareerSkills()
        {
            IDictionary<Career, IList<Skill>> careerSkills = new Dictionary<Career, IList<Skill>>();

            var careers = GetCarreers();
            foreach (var career in careers)
            {
                IList<Skill> skills = GetSkillsForCareer(career);
                careerSkills.Add(career, skills);
            }
            return careerSkills;
        }

        private IDictionary<Specialization, IList<Skill>> CreateSpecializationSkills()
        {
            IDictionary<Specialization, IList<Skill>> specializationSkills = new Dictionary<Specialization, IList<Skill>>();

            var specializations = GetSpecializations();
            foreach (var specialization in specializations)
            {
                IList<Skill> skills = GetSkillsForSpecialization(specialization);
                specializationSkills.Add(specialization, skills);
            }
            return specializationSkills;

            
        }

        private IList<TalentTree> CreateTalentTrees()
        {
            IList<TalentTree> talentTrees = new List<TalentTree>();
            talentTrees.Add(new TalentTree(GetSpecialization("Assassin"), new List<Talent>() { GetTalent("Grit"), GetTalent("Lethal Blows"), GetTalent("Stalker"), GetTalent("Dodge"), GetTalent("Precise Aim"), GetTalent("Jump Up"), GetTalent("Quick Strike"), GetTalent("Quick Draw"),
                GetTalent("Targeted Blow"), GetTalent("Stalker"), GetTalent("Lethal Blows"), GetTalent("Anatomy Lessons"), GetTalent("Stalker"), GetTalent("Sniper Shot"), GetTalent("Dodge"), GetTalent("Lethal Blows"), GetTalent("Precise Aim"), GetTalent("Deadly Accuracy"), GetTalent("Dedication"), GetTalent("Master of Shadows") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Gadgeteer"), new List<Talent>() {GetTalent("Brace"), GetTalent("Toughened"), GetTalent("Intimidating"), GetTalent("Defensive Stance"), GetTalent("Spare Clip"), GetTalent("Jury Rigged"), GetTalent("Point Blank"), GetTalent("Disorient"),
                GetTalent("Toughened"), GetTalent("Armor Master"), GetTalent("Natural Enforcer"), GetTalent("Stunning Blow"), GetTalent("Jury Rigged"), GetTalent("Tinkerer"), GetTalent("Deadly Accuracy"), GetTalent("Stunning Blow [Improved]"), GetTalent("Intimidating"), GetTalent("Dedication"), GetTalent("Armor Master [Improved]"), GetTalent("Crippling Blow") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Martial Artist"), new List<Talent>() {GetTalent("Iron Body"), GetTalent("Parry"), GetTalent("Grit"), GetTalent("Precision Strike"), GetTalent("Parry"), GetTalent("Toughened"), GetTalent("Martial Grace"), GetTalent("Grit"),GetTalent("Unarmed Parry"), GetTalent("Grapple"), GetTalent("Iron Body"), GetTalent("Precision Strike (Improved)"), GetTalent("Overbalance"), GetTalent("Toughened"), GetTalent("Mind Over Matter"), GetTalent("Grit"), GetTalent("Coordination Dodge"), GetTalent("Dedication"), GetTalent("Natural Brawler"), GetTalent("Precision Strike (Supreme)") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Operator"), new List<Talent>() {GetTalent("Grit"), GetTalent("Galaxy Mapper"), GetTalent("Shortcut"), GetTalent("Overwhelm Defenses"), GetTalent("Full Throttle"), GetTalent("Planet Mapper"), GetTalent("Grit"), GetTalent("Debilitating Shot"),GetTalent("Skilled Jockey"), GetTalent("All-Terrain Driver"), GetTalent("Offensive Driving"), GetTalent("Grit"), GetTalent("Let's Ride"), GetTalent("Shortcut"), GetTalent("Grit"), GetTalent("Overwhelm Defenses"), GetTalent("Dedication"), GetTalent("Shortcut (Improved)"), GetTalent("Skilled Jockey"), GetTalent("Hindering Shot") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Skip Tracer"), new List<Talent>() {GetTalent("Bypass Security"), GetTalent("Hard-Boiled"), GetTalent("Good Cop"), GetTalent("Rapid Recovery"), GetTalent("Toughened"), GetTalent("Expert Tracker"), GetTalent("Street Smarts"), GetTalent("Bought Info"),GetTalent("Hard-Boiled"), GetTalent("Rapid Recovery"), GetTalent("Street Smarts (Improved)"), GetTalent("Street Smarts"), GetTalent("Bypass Security"), GetTalent("Nobody's Fool"), GetTalent("Good Cop"), GetTalent("Informant"), GetTalent("Reconstruct the Scene"), GetTalent("Hard-Boiled"), GetTalent("Dedication"), GetTalent("Soft Spot") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Survivalist"), new List<Talent>() {GetTalent("Forager"), GetTalent("Stalker"), GetTalent("Outdoorsman"), GetTalent("Expert Tracker"), GetTalent("Outdoorsman"), GetTalent("Swift"), GetTalent("Hunter"), GetTalent("Soft Spot"),GetTalent("Toughened"), GetTalent("Expert Tracker"), GetTalent("Stalker"), GetTalent("Natural Outdoorsman"), GetTalent("Toughened"), GetTalent("Hunter"), GetTalent("Expert Tracker"), GetTalent("Blooded"), GetTalent("Enduring"), GetTalent("Dedication"), GetTalent("Grit"), GetTalent("Heroic Fortitude") }));


            talentTrees.Add(new TalentTree(GetSpecialization("Doctor"), new List<Talent>() {GetTalent("Surgeon"), GetTalent("Bacta Specialist"), GetTalent("Grit"), GetTalent("Resolve"), GetTalent("Stim Application"), GetTalent("Grit"), GetTalent("Surgeon"), GetTalent("Resolve"),GetTalent("Surgeon"), GetTalent("Grit"), GetTalent("Bacta Specialist"), GetTalent("Pressure Point"), GetTalent("Stim Application [Improved]"), GetTalent("Natural Doctor"), GetTalent("Toughened"), GetTalent("Anatomy Lessons"), GetTalent("Stim Application [Supreme]"), GetTalent("Master Doctor"), GetTalent("Dedication"), GetTalent("Dodge") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Entrepreneur"), new List<Talent>() {GetTalent("Sound Investments"), GetTalent("Plausible Deniability"), GetTalent("Rapid Recovery"), GetTalent("Grit"), GetTalent("Rapid Recovery"), GetTalent("Wheel and Deal"), GetTalent("Sound Investments"), GetTalent("Wheel and Deal"),GetTalent("Greased Palms"), GetTalent("Throwing Credits"), GetTalent("Bought Info"), GetTalent("Sound Investments"), GetTalent("Sound Investments"), GetTalent("Toughened"), GetTalent("Master Merchant"), GetTalent("Know Somebody"), GetTalent("Natural Merchant"), GetTalent("Intense Focus"), GetTalent("Dedication"), GetTalent("Sound Investments") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Marshal"), new List<Talent>() {GetTalent("Hard Headed"), GetTalent("Grit"), GetTalent("Street Smarts"), GetTalent("Toughened"), GetTalent("Durable"), GetTalent("Good Cop"), GetTalent("Bad Cop"), GetTalent("Quick Draw"),GetTalent("Hard Headed"), GetTalent("Grit"), GetTalent("Good Cop"), GetTalent("Point Blank"), GetTalent("Durable"), GetTalent("Unrelenting Skeptic"), GetTalent("Bad Cop"), GetTalent("Point Blank"), GetTalent("Hard Headed [Improved]"), GetTalent("Unrelenting Skeptic (Improved)"), GetTalent("Dedication"), GetTalent("Natural Marksman") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Performer"), new List<Talent>() {GetTalent("Smooth Talker"), GetTalent("Kill with Kindness"), GetTalent("Distracting Behavior"), GetTalent("Convincing Demeanor"), GetTalent("Distracting Behavior"), GetTalent("Congenial"), GetTalent("Dodge"), GetTalent("Jump Up"),GetTalent("Distracting Behavior"), GetTalent("Intense Presence"), GetTalent("Natural Athlete"), GetTalent("Second Wind"), GetTalent("Smooth Talker"), GetTalent("Distracting Behavior (Improved)"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Biggest Fan"), GetTalent("Deceptive Taunt"), GetTalent("Coordination Dodge"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Politico"), new List<Talent>() {GetTalent("Kill with Kindness"), GetTalent("Grit"), GetTalent("Plausible Deniability"), GetTalent("Toughened"), GetTalent("Inspiring Rhetoric"), GetTalent("Kill with Kindness"), GetTalent("Scathing Tirade"), GetTalent("Plausible Deniability"),GetTalent("Dodge"), GetTalent("Inspiring Rhetoric [Improved]"), GetTalent("Scathing Tirade [Improved]"), GetTalent("Well Rounded"), GetTalent("Grit"), GetTalent("Inspiring Rhetoric [Supreme]"), GetTalent("Scathing Tirade [Supreme]"), GetTalent("Nobody's Fool"), GetTalent("Steely Nerves"), GetTalent("Dedication"), GetTalent("Natural Charmer"), GetTalent("Intense Presence") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Scholar"), new List<Talent>() {GetTalent("Respected Scholar"), GetTalent("Speaks Binary"), GetTalent("Grit"), GetTalent("Brace"), GetTalent("Researcher"), GetTalent("Respected Scholar"), GetTalent("Resolve"), GetTalent("Researcher"),GetTalent("Codebreaker"), GetTalent("Knowledge Specialization"), GetTalent("Natural Scholar"), GetTalent("Well Rounded"), GetTalent("Knowledge Specialization"), GetTalent("Intense Focus"), GetTalent("Confidence"), GetTalent("Resolve"), GetTalent("Stroke of Genius"), GetTalent("Mental Fortress"), GetTalent("Dedication"), GetTalent("Toughened") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Archaeologist"), new List<Talent>() {GetTalent("Well Rounded"), GetTalent("Hard Headed"), GetTalent("Researcher"), GetTalent("Grit"), GetTalent("Durable"), GetTalent("Toughened"), GetTalent("Resolve"), GetTalent("Knowledge Specialization"),GetTalent("Stunning Blow"), GetTalent("Knockdown"), GetTalent("Respected Scholar"), GetTalent("Researcher"), GetTalent("Hard Headed"), GetTalent("Enduring"), GetTalent("Grit"), GetTalent("Knowledge Specialization"), GetTalent("Pin"), GetTalent("Dedication"), GetTalent("Respected Scholar"), GetTalent("Museum Worthy") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Big-Game Hunter"), new List<Talent>() {GetTalent("Forager"), GetTalent("Grit"), GetTalent("Stalker"), GetTalent("Outdoorsman"), GetTalent("Toughened"), GetTalent("Outdoorsman"), GetTalent("Confidence"), GetTalent("Swift"),GetTalent("Stalker"), GetTalent("Natural Hunter"), GetTalent("Expert Tracker"), GetTalent("Heightened Awareness"), GetTalent("Grit"), GetTalent("Hunter's Quarry"), GetTalent("Quick Strike"), GetTalent("Expert Tracker"), GetTalent("Bring it Down"), GetTalent("Hunter's Quarry [Improved]"), GetTalent("Dedication"), GetTalent("Superior Reflexes") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Driver"), new List<Talent>() {GetTalent("Full Throttle"), GetTalent("All-Terrain Driver"), GetTalent("Fine Tuning"), GetTalent("Gearhead"), GetTalent("Grit"), GetTalent("Skilled Jockey"), GetTalent("Rapid Reaction"), GetTalent("Grit"),GetTalent("Full Throttle [Improved]"), GetTalent("Tricky Target"), GetTalent("Fine Tuning"), GetTalent("Toughened"), GetTalent("Defensive Driving"), GetTalent("Skilled Jockey"), GetTalent("Natural Driver"), GetTalent("Gearhead"), GetTalent("Full Throttle [Supreme]"), GetTalent("Full Stop"), GetTalent("Master Driver"), GetTalent("Dedication") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Fringer"), new List<Talent>() {GetTalent("Galaxy Mapper"), GetTalent("Street Smarts"), GetTalent("Rapid Recovery"), GetTalent("Street Smarts"), GetTalent("Skilled Jockey"), GetTalent("Galaxy Mapper"), GetTalent("Grit"), GetTalent("Toughened"),GetTalent("Master Starhopper"), GetTalent("Defensive Driving"), GetTalent("Rapid Recovery"), GetTalent("Durable"), GetTalent("Rapid Recovery"), GetTalent("Jump Up"), GetTalent("Grit"), GetTalent("Knockdown"), GetTalent("Dedication"), GetTalent("Toughened"), GetTalent("Dodge"), GetTalent("Dodge") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Scout"), new List<Talent>() {GetTalent("Rapid Recovery"), GetTalent("Stalker"), GetTalent("Grit"), GetTalent("Shortcut"), GetTalent("Forager"), GetTalent("Quick Strike"), GetTalent("Let's Ride"), GetTalent("Disorient"),GetTalent("Rapid Recovery"), GetTalent("Natural Hunter"), GetTalent("Familiar Suns"), GetTalent("Shortcut"), GetTalent("Grit"), GetTalent("Heightened Awareness"), GetTalent("Toughened"), GetTalent("Quick Strike"), GetTalent("Utility Belt"), GetTalent("Dedication"), GetTalent("Stalker"), GetTalent("Disorient") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Trader"), new List<Talent>() {GetTalent("Know Somebody"), GetTalent("Convincing Demeanor"), GetTalent("Wheel and Deal"), GetTalent("Smooth Talker"), GetTalent("Wheel and Deal"), GetTalent("Grit"), GetTalent("Spare Clip"), GetTalent("Toughened"),GetTalent("Know Somebody"), GetTalent("Nobody's Fool"), GetTalent("Smooth Talker"), GetTalent("Nobody's Fool"), GetTalent("Wheel and Deal"), GetTalent("Steely Nerves"), GetTalent("Black Market Contacts"), GetTalent("Black Market Contacts"), GetTalent("Know Somebody"), GetTalent("Natural Negotiator"), GetTalent("Dedication"), GetTalent("Master Merchant") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Bodyguard"), new List<Talent>() {GetTalent("Toughened"), GetTalent("Barrage"), GetTalent("Durable"), GetTalent("Grit"), GetTalent("Body Guard"), GetTalent("Hard Headed"), GetTalent("Barrage"), GetTalent("Brace"),GetTalent("Body Guard"), GetTalent("Side Step"), GetTalent("Defensive Stance"), GetTalent("Brace"), GetTalent("Enduring"), GetTalent("Side Step"), GetTalent("Defensive Stance"), GetTalent("Hard Headed"), GetTalent("Dedication"), GetTalent("Barrage"), GetTalent("Toughened"), GetTalent("Hard Headed [Improved]") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Demolitionist"), new List<Talent>() {GetTalent("Powerful Blast"), GetTalent("Grit"), GetTalent("Selective Detonation"), GetTalent("Steady Nerves"), GetTalent("Toughened"), GetTalent("Time to Go"), GetTalent("Powerful Blast"), GetTalent("Grit"),GetTalent("Enduring"), GetTalent("Time to Go [Improved]"), GetTalent("Steady Nerves"), GetTalent("Rapid Reaction"), GetTalent("Improvised Detonation"), GetTalent("Powerful Blast"), GetTalent("Grit"), GetTalent("Selective Detonation"), GetTalent("Improvised Detonation [Improved]"), GetTalent("Dedication"), GetTalent("Master Grenadier"), GetTalent("Selective Detonation") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Enforcer"), new List<Talent>() {GetTalent("Toughened"), GetTalent("Intimidating"), GetTalent("Fearsome"), GetTalent("Street Smarts"), GetTalent("Durable"), GetTalent("Stunning Blow"), GetTalent("Natural Enforcer"), GetTalent("Talk the Talk"),GetTalent("Intimidating"), GetTalent("Defensive Stance"), GetTalent("Toughened"), GetTalent("Loom"), GetTalent("Second Wind"), GetTalent("Street Smarts"), GetTalent("Walk the Walk"), GetTalent("Intimidating"), GetTalent("Fearsome"), GetTalent("Dedication"), GetTalent("Black Market Contacts"), GetTalent("Fearsome") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Heavy"), new List<Talent>() {GetTalent("Burly"), GetTalent("Barrage"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Barrage"), GetTalent("Brace"), GetTalent("Spare Clip"), GetTalent("Durable"),GetTalent("Side Step"), GetTalent("Burly"), GetTalent("Heroic Fortitude"), GetTalent("Toughened"), GetTalent("Brace"), GetTalent("Barrage"), GetTalent("Rain of Death"), GetTalent("Heroic Resilience"), GetTalent("Burly"), GetTalent("Dedication"), GetTalent("Armor Master"), GetTalent("Heavy Hitter") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Marauder"), new List<Talent>() {GetTalent("Toughened"), GetTalent("Frenzied Attack"), GetTalent("Feral Strength"), GetTalent("Lethal Blows"), GetTalent("Feral Strength"), GetTalent("Toughened"), GetTalent("Heroic Fortitude"), GetTalent("Knockdown"),GetTalent("Enduring"), GetTalent("Lethal Blows"), GetTalent("Toughened"), GetTalent("Frenzied Attack"), GetTalent("Toughened"), GetTalent("Feral Strength"), GetTalent("Natural Brawler"), GetTalent("Lethal Blows"), GetTalent("Frenzied Attack"), GetTalent("Enduring"), GetTalent("Defensive Stance"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Mercenary Soldier"), new List<Talent>() {GetTalent("Command"), GetTalent("Second Wind"), GetTalent("Point Blank"), GetTalent("Side Step"), GetTalent("Second Wind"), GetTalent("Confidence"), GetTalent("Strong Arm"), GetTalent("Point Blank"),GetTalent("Field Commander"), GetTalent("Command"), GetTalent("Natural Marksman"), GetTalent("Sniper Shot"), GetTalent("Field Commander [Improved]"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Lethal Blows"), GetTalent("Deadly Accuracy"), GetTalent("True Aim"), GetTalent("Dedication"), GetTalent("True Aim") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Charmer"), new List<Talent>() {GetTalent("Smooth Talker"), GetTalent("Inspiring Rhetoric"), GetTalent("Kill with Kindness"), GetTalent("Grit"), GetTalent("Kill with Kindness"), GetTalent("Inspiring Rhetoric [Improved]"), GetTalent("Congenial"), GetTalent("Plausible Deniability"),GetTalent("Disarming Smile"), GetTalent("Works Like a Charm"), GetTalent("Disarming Smile"), GetTalent("Grit"), GetTalent("Smooth Talker"), GetTalent("Congenial"), GetTalent("Just Kidding!"), GetTalent("Intense Presence"), GetTalent("Natural Charmer"), GetTalent("Dedication"), GetTalent("Don't Shoot"), GetTalent("Resolve") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Gambler"), new List<Talent>() {GetTalent("Convincing Demeanor"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Up the Ante"), GetTalent("Grit"), GetTalent("Second Chances"), GetTalent("Dedication"), GetTalent("Double or Nothing (Supreme)"),GetTalent("Second Chances"), GetTalent("Convincing Demeanor"), GetTalent("Fortune Favors the Bold"), GetTalent("Natural Rogue"), GetTalent("Up the Ante"), GetTalent("Up the Ante"), GetTalent("Clever Solution"), GetTalent("Second Chances"), GetTalent("Double or Nothing"), GetTalent("Smooth Talker"), GetTalent("Natural Negotiator"), GetTalent("Double or Nothing (Improved)") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Gunslinger"), new List<Talent>() {GetTalent("Grit"), GetTalent("Quick Strike"), GetTalent("Rapid Reaction"), GetTalent("Quick Draw"), GetTalent("Lethal Blows"), GetTalent("Grit"), GetTalent("Quick Strike"), GetTalent("Quick Draw (Improved)"),GetTalent("Toughened"), GetTalent("Call 'em"), GetTalent("Dodge"), GetTalent("Sorry About the Mess"), GetTalent("Confidence"), GetTalent("Lethal Blows"), GetTalent("Guns Blazing"), GetTalent("Rapid Reaction"), GetTalent("Dedication"), GetTalent("Spitfire"), GetTalent("Natural Marksman"), GetTalent("Deadly Accuracy") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Pilot"), new List<Talent>() {GetTalent("Full Throttle"), GetTalent("Skilled Jockey"), GetTalent("Galaxy Mapper"), GetTalent("Let's Ride"), GetTalent("Skilled Jockey"), GetTalent("Dead to Rights"), GetTalent("Galaxy Mapper"), GetTalent("Rapid Recovery"),GetTalent("Full Throttle [Improved]"), GetTalent("Dead to Rights [Improved]"), GetTalent("Grit"), GetTalent("Natural Pilot"), GetTalent("Grit"), GetTalent("Full Throttle [Supreme]"), GetTalent("Tricky Target"), GetTalent("Defensive Driving"), GetTalent("Master Pilot"), GetTalent("Dedication"), GetTalent("Toughened"), GetTalent("Brilliant Evasion") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Scoundrel"), new List<Talent>() {GetTalent("Black Market Contacts"), GetTalent("Convincing Demeanor"), GetTalent("Quick Draw"), GetTalent("Rapid Reaction"), GetTalent("Convincing Demeanor"), GetTalent("Black Market Contacts"), GetTalent("Convincing Demeanor"), GetTalent("Quick Strike"),GetTalent("Hidden Storage"), GetTalent("Toughened"), GetTalent("Black Market Contacts"), GetTalent("Side Step"), GetTalent("Toughened"), GetTalent("Rapid Reaction"), GetTalent("Hidden Storage"), GetTalent("Side Step"), GetTalent("Dedication"), GetTalent("Natural Charmer"), GetTalent("Soft Spot"), GetTalent("Quick Strike") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Thief"), new List<Talent>() {GetTalent("Street Smarts"), GetTalent("Black Market Contacts"), GetTalent("Indistinguishable"), GetTalent("Bypass Security"), GetTalent("Black Market Contacts"), GetTalent("Dodge"), GetTalent("Grit"), GetTalent("Hidden Storage"),GetTalent("Stalker"), GetTalent("Grit"), GetTalent("Rapid Reaction"), GetTalent("Shortcut"), GetTalent("Bypass Security"), GetTalent("Natural Rogue"), GetTalent("Street Smarts"), GetTalent("Jump Up"), GetTalent("Master of Shadows"), GetTalent("Dodge"), GetTalent("Indistinguishable"), GetTalent("Dedication") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Cyber Tech"), new List<Talent>() {GetTalent("Cyberneticist"), GetTalent("More Machine than Man"), GetTalent("Engineered Redundancies"), GetTalent("Toughened"), GetTalent("Eye for Detail"), GetTalent("Toughened"), GetTalent("Energy Transfer"), GetTalent("Cyberneticist"),GetTalent("Overcharge"), GetTalent("More Machine than Man"), GetTalent("Durable"), GetTalent("Surgeon"), GetTalent("Overcharge (Improved)"), GetTalent("Utility Belt"), GetTalent("More Machine than Man"), GetTalent("Surgeon"), GetTalent("More Machine than Man"), GetTalent("Durable"), GetTalent("Overcharge (Supreme)"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Droid Tech"), new List<Talent>() {GetTalent("Machine Mender"), GetTalent("Hidden Storage"), GetTalent("Speaks Binary"), GetTalent("Grit"), GetTalent("Deft Maker"), GetTalent("Eye for Detail"), GetTalent("Grit"), GetTalent("Speaks Binary"),GetTalent("Grit"), GetTalent("Speaks Binary (Supreme)"), GetTalent("Speaks Binary (Improved)"), GetTalent("Hidden Storage"), GetTalent("Redundant Systems"), GetTalent("Machine Mender"), GetTalent("Speaks Binary"), GetTalent("Deft Maker"), GetTalent("Eye for Detail"), GetTalent("Reroute Processors"), GetTalent("Dedication"), GetTalent("Machine Mender") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Mechanic"), new List<Talent>() {GetTalent("Gearhead"), GetTalent("Toughened"), GetTalent("Fine Tuning"), GetTalent("Solid Repairs"), GetTalent("Redundant Systems"), GetTalent("Solid Repairs"), GetTalent("Gearhead"), GetTalent("Grit"),GetTalent("Solid Repairs"), GetTalent("Enduring"), GetTalent("Bad Motivator"), GetTalent("Toughened"), GetTalent("Contraption"), GetTalent("Solid Repairs"), GetTalent("Fine Tuning"), GetTalent("Hard Headed"), GetTalent("Natural Tinkerer"), GetTalent("Hold Together"), GetTalent("Dedication"), GetTalent("Hard Headed [Improved]") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Modder"), new List<Talent>() {GetTalent("Tinkerer"), GetTalent("Resolve"), GetTalent("Know Somebody"), GetTalent("Signature Vehicle"), GetTalent("Gearhead"), GetTalent("Tinkerer"), GetTalent("Fancy Paint Job"), GetTalent("Larger Project"),GetTalent("Resourceful Refit"), GetTalent("Resolve"), GetTalent("Larger Project"), GetTalent("Toughened"), GetTalent("Jury Rigged"), GetTalent("Hidden Storage"), GetTalent("Tinkerer"), GetTalent("Gearhead"), GetTalent("Jury Rigged"), GetTalent("Dedication"), GetTalent("Natural Tinkerer"), GetTalent("Custom Loadout") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Outlaw Tech"), new List<Talent>() {GetTalent("Tinkerer"), GetTalent("Utinni!"), GetTalent("Speaks Binary"), GetTalent("Tinkerer"), GetTalent("Solid Repairs"), GetTalent("Grit"), GetTalent("Utinni!"), GetTalent("Toughened"),GetTalent("Utility Belt"), GetTalent("Side Step"), GetTalent("Brace"), GetTalent("Defensive Stance"), GetTalent("Jury Rigged"), GetTalent("Speaks Binary"), GetTalent("Inventor"), GetTalent("Jury Rigged"), GetTalent("Inventor"), GetTalent("Dedication"), GetTalent("Known Schematic"), GetTalent("Brace") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Slicer"), new List<Talent>() {GetTalent("Codebreaker"), GetTalent("Grit"), GetTalent("Technical Aptitude"), GetTalent("Bypass Security"), GetTalent("Defensive Slicing"), GetTalent("Technical Aptitude"), GetTalent("Grit"), GetTalent("Bypass Security"),GetTalent("Natural Programmer"), GetTalent("Bypass Security"), GetTalent("Defensive Slicing"), GetTalent("Grit"), GetTalent("Defensive Slicing"), GetTalent("Defensive Slicing [Improved]"), GetTalent("Codebreaker"), GetTalent("Resolve"), GetTalent("Skilled Slicer"), GetTalent("Master Slicer"), GetTalent("Mental Fortress"), GetTalent("Dedication") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Beast Rider"), new List<Talent>() {GetTalent("Forager"), GetTalent("Toughened"), GetTalent("Outdoorsman"), GetTalent("Beast Wrangler"), GetTalent("Outdoorsman"), GetTalent("Expert Tracker"), GetTalent("Toughened"), GetTalent("Expert Handler"),GetTalent("Expert Tracker"), GetTalent("Beast Wrangler"), GetTalent("Let's Ride"), GetTalent("Grit"), GetTalent("Spur [Improved]"), GetTalent("Spur"), GetTalent("Natural Outdoorsman"), GetTalent("Expert Handler"), GetTalent("Spur [Supreme]"), GetTalent("Dedication"), GetTalent("Grit"), GetTalent("Soothing Tone") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Driver Ace"), new List<Talent>() {GetTalent("Full Throttle"), GetTalent("All-Terrain Driver"), GetTalent("Fine Tuning"), GetTalent("Gearhead"), GetTalent("Grit"), GetTalent("Skilled Jockey"), GetTalent("Rapid Reaction"), GetTalent("Grit"),GetTalent("Full Throttle [Improved]"), GetTalent("Tricky Target"), GetTalent("Fine Tuning"), GetTalent("Toughened"), GetTalent("Defensive Driving"), GetTalent("Skilled Jockey"), GetTalent("Natural Driver"), GetTalent("Gearhead"), GetTalent("Full Throttle [Supreme]"), GetTalent("Full Stop"), GetTalent("Master Driver"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Gunner"), new List<Talent>() {GetTalent("Durable"), GetTalent("Grit"), GetTalent("Overwhelm Defenses"), GetTalent("Debilitating Shot"), GetTalent("Toughened"), GetTalent("Brace"), GetTalent("Spare Clip"), GetTalent("True Aim"),GetTalent("Durable"), GetTalent("Enduring"), GetTalent("Jury Rigged"), GetTalent("Overwhelm Defenses"), GetTalent("Toughened"), GetTalent("Enduring"), GetTalent("Brace"), GetTalent("Exhaust Port"), GetTalent("Heroic Fortitude"), GetTalent("Jury Rigged"), GetTalent("Dedication"), GetTalent("True Aim") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Hotshot"), new List<Talent>() {GetTalent("Shortcut"), GetTalent("High-G Training"), GetTalent("Skilled Jockey"), GetTalent("Grit"), GetTalent("Second Chances"), GetTalent("Grit"), GetTalent("Shortcut"), GetTalent("High-G Training"),GetTalent("Dead to Rights"), GetTalent("High-G Training"), GetTalent("Grit"), GetTalent("Intense Presence"), GetTalent("Second Chances"), GetTalent("Corellian Sendoff"), GetTalent("Koiogran Turn"), GetTalent("Grit"), GetTalent("Dead to Rights [Improved]"), GetTalent("Corellian Sendoff [Improved]"), GetTalent("Dedication"), GetTalent("Showboat") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Pilot Ace"), new List<Talent>() {GetTalent("Full Throttle"), GetTalent("Skilled Jockey"), GetTalent("Galaxy Mapper"), GetTalent("Let's Ride"), GetTalent("Skilled Jockey"), GetTalent("Dead to Rights"), GetTalent("Galaxy Mapper"), GetTalent("Rapid Recovery"),GetTalent("Full Throttle [Improved]"), GetTalent("Dead to Rights [Improved]"), GetTalent("Grit"), GetTalent("Natural Pilot"), GetTalent("Grit"), GetTalent("Full Throttle [Supreme]"), GetTalent("Tricky Target"), GetTalent("Defensive Driving"), GetTalent("Master Pilot"), GetTalent("Dedication"), GetTalent("Toughened"), GetTalent("Brilliant Evasion") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Rigger"), new List<Talent>() {GetTalent("Black Market Contacts"), GetTalent("Toughened"), GetTalent("Gearhead"), GetTalent("Larger Project"), GetTalent("Grit"), GetTalent("Fancy Paint Job"), GetTalent("Signature Vehicle"), GetTalent("Larger Project"),GetTalent("Black Market Contacts"), GetTalent("Overstocked Ammo"), GetTalent("Tuned Maneuvering Thrusters"), GetTalent("Bolstered Armor"), GetTalent("Toughened"), GetTalent("Customized Cooling Unit"), GetTalent("Gearhead"), GetTalent("Fortified Vacuum Seal"), GetTalent("Dedication"), GetTalent("Tuned Maneuvering Thrusters"), GetTalent("Not Today"), GetTalent("Reinforced Frame") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Commodore"), new List<Talent>() {GetTalent("Solid Repairs"), GetTalent("Command"), GetTalent("Rapid Reaction"), GetTalent("Galaxy Mapper"), GetTalent("Known Schematic"), GetTalent("Commanding Presence"), GetTalent("Grit"), GetTalent("Familiar Suns"),GetTalent("Solid Repairs"), GetTalent("Command"), GetTalent("Rapid Reaction"), GetTalent("Galaxy Mapper"), GetTalent("Hold Together"), GetTalent("Commanding Presence"), GetTalent("Grit"), GetTalent("Master Starhopper"), GetTalent("Solid Repairs"), GetTalent("Fire Control"), GetTalent("Dedication"), GetTalent("Galaxy Mapper") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Figurehead"), new List<Talent>() {GetTalent("Grit"), GetTalent("Resolve"), GetTalent("Confidence"), GetTalent("Command"), GetTalent("Command"), GetTalent("Inspiring Rhetoric"), GetTalent("Calm Commander"), GetTalent("Grit"),GetTalent("Commanding Presence"), GetTalent("Grit"), GetTalent("Inspiring Rhetoric [Improved]"), GetTalent("Positive Spin"), GetTalent("Resolve"), GetTalent("Confidence"), GetTalent("Confidence (Improved)"), GetTalent("Commanding Presence"), GetTalent("Intense Presence"), GetTalent("Natural Leader"), GetTalent("Dedication"), GetTalent("Commanding Presence (Improved)") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Instructor"), new List<Talent>() {GetTalent("Conditioned"), GetTalent("Physical Training"), GetTalent("Body Guard"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Encouraging Words"), GetTalent("Conditioned"), GetTalent("Stimpack Specialization"),GetTalent("Physical Training"), GetTalent("Master Instructor"), GetTalent("Body Guard"), GetTalent("Body Guard (Improved)"), GetTalent("Field Commander"), GetTalent("Grit"), GetTalent("Stimpack Specialization"), GetTalent("Toughened"), GetTalent("Field Commander [Improved]"), GetTalent("Natural Instructor"), GetTalent("That's how it's Done"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Squadron Leader"), new List<Talent>() {GetTalent("Grit"), GetTalent("Quick Strike"), GetTalent("Let's Ride"), GetTalent("Defensive Driving"), GetTalent("Field Commander"), GetTalent("Confidence"), GetTalent("Quick Strike"), GetTalent("Situational Awareness"),GetTalent("Command"), GetTalent("Grit"), GetTalent("Full Stop"), GetTalent("Defensive Driving"), GetTalent("Field Commander [Improved]"), GetTalent("Command"), GetTalent("Form on Me"), GetTalent("Tricky Target"), GetTalent("Master Leader"), GetTalent("Confidence"), GetTalent("Dedication"), GetTalent("Brilliant Evasion") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Strategist"), new List<Talent>() {GetTalent("Researcher"), GetTalent("Grit"), GetTalent("Ready for Anything"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Clever Commander"), GetTalent("Command"), GetTalent("Well Read"),GetTalent("Knowledge Specialization"), GetTalent("Researcher"), GetTalent("Ready for Anything"), GetTalent("Master Strategist"), GetTalent("Researcher (Improved)"), GetTalent("Knowledge Specialization"), GetTalent("Coordinated Assault"), GetTalent("Command"), GetTalent("Thorough Assessment"), GetTalent("Careful Planning"), GetTalent("Ready for Anything [Improved]"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Tactician"), new List<Talent>() {GetTalent("Outdoorsman"), GetTalent("Commanding Presence"), GetTalent("Toughened"), GetTalent("Side Step"), GetTalent("Outdoorsman"), GetTalent("Confidence"), GetTalent("Quick Draw"), GetTalent("Swift"),GetTalent("Natural Outdoorsman"), GetTalent("Toughened"), GetTalent("Body Guard"), GetTalent("Body Guard"), GetTalent("Confidence"), GetTalent("Commanding Presence"), GetTalent("Field Commander"), GetTalent("Side Step"), GetTalent("Coordinated Assault"), GetTalent("Natural Leader"), GetTalent("Field Commander [Improved]"), GetTalent("Dedication") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Advocate"), new List<Talent>() {GetTalent("Plausible Deniability"), GetTalent("Nobody's Fool"), GetTalent("Grit"), GetTalent("Confidence"), GetTalent("Discredit"), GetTalent("Plausible Deniability"), GetTalent("Supporting Evidence"), GetTalent("Nobody's Fool"),GetTalent("Twisted Words"), GetTalent("Plausible Deniability (Improved)"), GetTalent("Grit"), GetTalent("Encouraging Words"), GetTalent("Plausible Deniability"), GetTalent("Grit"), GetTalent("Supporting Evidence"), GetTalent("Grit"), GetTalent("Blackmail"), GetTalent("Dedication"), GetTalent("Interjection"), GetTalent("Contingency Plan") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Agitator"), new List<Talent>() { GetTalent("Plausible Deniability"), GetTalent("Nobody's Fool"), GetTalent("Grit"), GetTalent("Intimidating"), GetTalent("Street Smarts"), GetTalent("Street Smarts"), GetTalent("Convincing Demeanor"), GetTalent("Intimidating"), GetTalent("Convincing Demeanor"), GetTalent("Plausible Deniability"), GetTalent("Scathing Tirade"), GetTalent("Grit"), GetTalent("Natural Enforcer"), GetTalent("Nobody's Fool"), GetTalent("Scathing Tirade [Improved]"), GetTalent("Intimidating"), GetTalent("Intimidating"), GetTalent("Dedication"), GetTalent("Scathing Tirade [Supreme]"), GetTalent("Incite Rebellion") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Ambassador"), new List<Talent>() {GetTalent("Indistinguishable"), GetTalent("Kill with Kindness"), GetTalent("Nobody's Fool"), GetTalent("Confidence"), GetTalent("Indistinguishable"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Dodge"),GetTalent("Kill with Kindness"), GetTalent("Inspiring Rhetoric"), GetTalent("Steely Nerves"), GetTalent("Confidence"), GetTalent("Inspiring Rhetoric [Improved]"), GetTalent("Intense Presence"), GetTalent("Works Like a Charm"), GetTalent("Dodge"), GetTalent("Inspiring Rhetoric [Supreme]"), GetTalent("Natural Charmer"), GetTalent("Dedication"), GetTalent("Sixth Sense") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Analyst"), new List<Talent>() {GetTalent("Researcher"), GetTalent("Knowledge Specialization"), GetTalent("Codebreaker"), GetTalent("Technical Aptitude"), GetTalent("Valuable Facts"), GetTalent("Researcher"), GetTalent("Supporting Evidence"), GetTalent("Grit"),GetTalent("Knowledge Specialization"), GetTalent("Researcher (Improved)"), GetTalent("Codebreaker"), GetTalent("Encoded Communique"), GetTalent("Grit"), GetTalent("Know-It-All"), GetTalent("Knowledge Specialization"), GetTalent("Natural Programmer"), GetTalent("Dedication"), GetTalent("Knowledge Specialization"), GetTalent("Thorough Assessment"), GetTalent("Stroke of Genius") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Propagandist"), new List<Talent>() {GetTalent("Grit"), GetTalent("Positive Spin"), GetTalent("In the Know"), GetTalent("Cutting Question"), GetTalent("In the Know"), GetTalent("Positive Spin (Improved)"), GetTalent("Positive Spin"), GetTalent("Toughened"),GetTalent("Bad Press"), GetTalent("Well Rounded"), GetTalent("Grit"), GetTalent("Confidence"), GetTalent("Toughened"), GetTalent("Confidence"), GetTalent("Dodge"), GetTalent("Informant"), GetTalent("Positive Spin"), GetTalent("Dedication"), GetTalent("In the Know (Improved)"), GetTalent("In the Know") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Quartermaster"), new List<Talent>() {GetTalent("Know Somebody"), GetTalent("Smooth Talker"), GetTalent("Wheel and Deal"), GetTalent("Grit"), GetTalent("Smooth Talker"), GetTalent("Greased Palms"), GetTalent("Master Merchant"), GetTalent("Toughened"),GetTalent("Grit"), GetTalent("Wheel and Deal"), GetTalent("Bought Info"), GetTalent("Grit"), GetTalent("Know Somebody"), GetTalent("Sound Investments"), GetTalent("Sound Investments"), GetTalent("Intense Focus"), GetTalent("Dedication"), GetTalent("Natural Negotiator"), GetTalent("Superior Reflexes"), GetTalent("Toughened") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Mechanic Engineer"), new List<Talent>() {GetTalent("Gearhead"), GetTalent("Toughened"), GetTalent("Fine Tuning"), GetTalent("Solid Repairs"), GetTalent("Redundant Systems"), GetTalent("Solid Repairs"), GetTalent("Gearhead"), GetTalent("Grit"),GetTalent("Solid Repairs"), GetTalent("Enduring"), GetTalent("Bad Motivator"), GetTalent("Toughened"), GetTalent("Contraption"), GetTalent("Solid Repairs"), GetTalent("Fine Tuning"), GetTalent("Hard Headed"), GetTalent("Natural Tinkerer"), GetTalent("Hold Together"), GetTalent("Dedication"), GetTalent("Hard Headed [Improved]") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Saboteur"), new List<Talent>() {GetTalent("Resolve"), GetTalent("Second Wind"), GetTalent("Grit"), GetTalent("Rapid Recovery"), GetTalent("Grit"), GetTalent("Powerful Blast"), GetTalent("Toughened"), GetTalent("Second Wind"),GetTalent("Time to Go"), GetTalent("Rapid Recovery"), GetTalent("Resolve"), GetTalent("Hard Headed"), GetTalent("Time to Go [Improved]"), GetTalent("Powerful Blast"), GetTalent("Selective Detonation"), GetTalent("Toughened"), GetTalent("Dedication"), GetTalent("Master Grenadier"), GetTalent("Selective Detonation"), GetTalent("Hard Headed [Improved]") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Scientist"), new List<Talent>() {GetTalent("Knowledge Specialization"), GetTalent("Respected Scholar"), GetTalent("Researcher"), GetTalent("Speaks Binary"), GetTalent("Researcher"), GetTalent("Knowledge Specialization"), GetTalent("Hidden Storage"), GetTalent("Tinkerer"),GetTalent("Respected Scholar"), GetTalent("Mental Fortress"), GetTalent("Speaks Binary"), GetTalent("Inventor"), GetTalent("Natural Scholar"), GetTalent("Stroke of Genius"), GetTalent("Inventor"), GetTalent("Tinkerer"), GetTalent("Intense Focus"), GetTalent("Careful Planning"), GetTalent("Dedication"), GetTalent("Utility Belt") }));
            talentTrees.Add(new TalentTree(GetSpecialization("eng1"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("eng2"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("eng3"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Commando"), new List<Talent>() {GetTalent("Physical Training"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Point Blank"), GetTalent("Toughened"), GetTalent("Durable"), GetTalent("Physical Training"), GetTalent("Strong Arm"),GetTalent("Blooded"), GetTalent("Armor Master"), GetTalent("Natural Outdoorsman"), GetTalent("Feral Strength"), GetTalent("Toughened"), GetTalent("Heroic Fortitude"), GetTalent("Durable"), GetTalent("Knockdown"), GetTalent("Armor Master [Improved]"), GetTalent("Dedication"), GetTalent("Unstoppable"), GetTalent("Feral Strength") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Heavy Soldier"), new List<Talent>() {GetTalent("Burly"), GetTalent("Barrage"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Barrage"), GetTalent("Brace"), GetTalent("Spare Clip"), GetTalent("Durable"),GetTalent("Side Step"), GetTalent("Burly"), GetTalent("Heroic Fortitude"), GetTalent("Toughened"), GetTalent("Brace"), GetTalent("Barrage"), GetTalent("Rain of Death"), GetTalent("Heroic Resilience"), GetTalent("Burly"), GetTalent("Dedication"), GetTalent("Armor Master"), GetTalent("Heavy Hitter") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Medic"), new List<Talent>() {GetTalent("Forager"), GetTalent("Stimpack Specialization"), GetTalent("Grit"), GetTalent("Surgeon"), GetTalent("Toughened"), GetTalent("Surgeon"), GetTalent("Stimpack Specialization"), GetTalent("Bacta Specialist"),GetTalent("Well Rounded"), GetTalent("Grit"), GetTalent("Stim Application"), GetTalent("Master Doctor"), GetTalent("Dodge"), GetTalent("Natural Doctor"), GetTalent("Stim Application [Improved]"), GetTalent("Stimpack Specialization"), GetTalent("Anatomy Lessons"), GetTalent("Dedication"), GetTalent("It's Not That Bad"), GetTalent("Stim Application [Supreme]") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Sharpshooter"), new List<Talent>() {GetTalent("Expert Tracker"), GetTalent("Sniper Shot"), GetTalent("Brace"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("True Aim"), GetTalent("Deadly Accuracy"), GetTalent("Lethal Blows"),GetTalent("Brace"), GetTalent("Lethal Blows"), GetTalent("Sniper Shot"), GetTalent("True Aim"), GetTalent("Expert Tracker"), GetTalent("Deadly Accuracy"), GetTalent("Toughened"), GetTalent("Crippling Blow"), GetTalent("Quick Fix"), GetTalent("Natural Marksman"), GetTalent("Dedication"), GetTalent("Targeted Blow") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Trailblazer"), new List<Talent>() {GetTalent("Stalker"), GetTalent("Toughened"), GetTalent("Outdoorsman"), GetTalent("Expert Tracker"), GetTalent("Disorient"), GetTalent("Prime Positions"), GetTalent("Cunning Snare"), GetTalent("Outdoorsman"),GetTalent("Grit"), GetTalent("Dodge"), GetTalent("Blind Spot"), GetTalent("Toughened"), GetTalent("Dodge"), GetTalent("Prey on the Weak"), GetTalent("Expert Tracker"), GetTalent("One with Nature"), GetTalent("Dedication"), GetTalent("Ambush"), GetTalent("Disorient"), GetTalent("Prey on the Weak") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Vanguard"), new List<Talent>() {GetTalent("Body Guard"), GetTalent("Conditioned"), GetTalent("Toughened"), GetTalent("Rapid Reaction"), GetTalent("Toughened"), GetTalent("Moving Target"), GetTalent("Point Blank"), GetTalent("Suppressing Fire"),GetTalent("Conditioned"), GetTalent("Body Guard"), GetTalent("Toughened"), GetTalent("Rapid Reaction"), GetTalent("Body Guard (Improved)"), GetTalent("Toughened"), GetTalent("Suppressing Fire"), GetTalent("Moving Target"), GetTalent("Dedication"), GetTalent("Body Guard (Supreme)"), GetTalent("Dynamic Fire"), GetTalent("Seize the Initiative") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Infiltrator"), new List<Talent>() {GetTalent("Grit"), GetTalent("Dodge"), GetTalent("Frenzied Attack"), GetTalent("Defensive Stance"), GetTalent("Stunning Blow"), GetTalent("Grit"), GetTalent("Soft Spot"), GetTalent("Jump Up"),GetTalent("Knockdown"), GetTalent("Frenzied Attack"), GetTalent("Grit"), GetTalent("Dodge"), GetTalent("Natural Brawler"), GetTalent("Toughened"), GetTalent("Stunning Blow [Improved]"), GetTalent("Defensive Stance"), GetTalent("Dedication"), GetTalent("Clever Solution"), GetTalent("Master of Shadows"), GetTalent("Natural Rogue") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Scout Spy"), new List<Talent>() {GetTalent("Rapid Recovery"), GetTalent("Stalker"), GetTalent("Grit"), GetTalent("Shortcut"), GetTalent("Forager"), GetTalent("Quick Strike"), GetTalent("Let's Ride"), GetTalent("Disorient"),GetTalent("Rapid Recovery"), GetTalent("Natural Hunter"), GetTalent("Familiar Suns"), GetTalent("Shortcut"), GetTalent("Grit"), GetTalent("Heightened Awareness"), GetTalent("Toughened"), GetTalent("Quick Strike"), GetTalent("Utility Belt"), GetTalent("Dedication"), GetTalent("Stalker"), GetTalent("Disorient") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Slicer Spy"), new List<Talent>() {GetTalent("Codebreaker"), GetTalent("Grit"), GetTalent("Technical Aptitude"), GetTalent("Bypass Security"), GetTalent("Defensive Slicing"), GetTalent("Technical Aptitude"), GetTalent("Grit"), GetTalent("Bypass Security"),GetTalent("Natural Programmer"), GetTalent("Bypass Security"), GetTalent("Defensive Slicing"), GetTalent("Grit"), GetTalent("Defensive Slicing"), GetTalent("Defensive Slicing [Improved]"), GetTalent("Codebreaker"), GetTalent("Resolve"), GetTalent("Skilled Slicer"), GetTalent("Master Slicer"), GetTalent("Mental Fortress"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("spy1"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("spy2"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("spy3"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Healer"), new List<Talent>() {GetTalent("Surgeon"), GetTalent("Healing Trance"), GetTalent("Rapid Recovery"), GetTalent("Physician"), GetTalent("Physician"), GetTalent("Physician"), GetTalent("Grit"), GetTalent("Healing Trance"),GetTalent("Healing Trance"), GetTalent("Grit"), GetTalent("Knowledgeable Healing"), GetTalent("Rapid Recovery"), GetTalent("Surgeon"), GetTalent("Healing Trance (Improved)"), GetTalent("Calming Aura"), GetTalent("Toughened"), GetTalent("Dedication"), GetTalent("Natural Doctor"), GetTalent("Force Rating"), GetTalent("Calming Aura (Improved)") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Niman Disciple"), new List<Talent>() {GetTalent("Parry"), GetTalent("Nobody's Fool"), GetTalent("Reflect"), GetTalent("Grit"), GetTalent("Defensive Training"), GetTalent("Niman Technique"), GetTalent("Toughened"), GetTalent("Parry"),GetTalent("Parry"), GetTalent("Sense Emotions"), GetTalent("Reflect"), GetTalent("Defensive Training"), GetTalent("Sum Djem"), GetTalent("Reflect"), GetTalent("Draw Closer"), GetTalent("Center of Being"), GetTalent("Dedication"), GetTalent("Force Assault"), GetTalent("Force Rating"), GetTalent("Center of Being (Improved)") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Sage"), new List<Talent>() {GetTalent("Grit"), GetTalent("Kill with Kindness"), GetTalent("Researcher"), GetTalent("Grit"), GetTalent("Smooth Talker"), GetTalent("Researcher"), GetTalent("Confidence"), GetTalent("Knowledge Specialization"),GetTalent("Valuable Facts"), GetTalent("Smooth Talker"), GetTalent("Knowledge Specialization"), GetTalent("One With the Universe"), GetTalent("Force Rating"), GetTalent("Grit"), GetTalent("Preemptive Avoidance"), GetTalent("Knowledge Specialization"), GetTalent("Balance"), GetTalent("The Force is my Ally"), GetTalent("Natural Negotiator"), GetTalent("Force Rating") }));
            talentTrees.Add(new TalentTree(GetSpecialization("con1"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("con2"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("con3"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Armorer"), new List<Talent>() {GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Gearhead"), GetTalent("Inventor"), GetTalent("Saber Throw"), GetTalent("Armor Master"), GetTalent("Grit"), GetTalent("Gearhead"),GetTalent("Toughened"), GetTalent("Armor Master [Improved]"), GetTalent("Inventor"), GetTalent("Mental Tools"), GetTalent("Comprehend Technology"), GetTalent("Tinkerer"), GetTalent("Falling Avalanche"), GetTalent("Armor Master (Supreme)"), GetTalent("Force Rating"), GetTalent("Imbue Item"), GetTalent("Reinforce Item"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Peacekeeper"), new List<Talent>() {GetTalent("Command"), GetTalent("Confidence"), GetTalent("Second Wind"), GetTalent("Commanding Presence"), GetTalent("Commanding Presence"), GetTalent("Toughened"), GetTalent("Second Wind"), GetTalent("Confidence"),GetTalent("Toughened"), GetTalent("Enhanced Leader"), GetTalent("Command"), GetTalent("Field Commander"), GetTalent("Steely Nerves"), GetTalent("Second Wind"), GetTalent("Toughened"), GetTalent("Field Commander [Improved]"), GetTalent("Unity Assault"), GetTalent("Dedication"), GetTalent("Force Rating"), GetTalent("Natural Leader") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Protector"), new List<Talent>() {GetTalent("Toughened"), GetTalent("Body Guard"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Parry"), GetTalent("Physician"), GetTalent("Stimpack Specialization"), GetTalent("Force Protection"),GetTalent("Reflect"), GetTalent("Stimpack Specialization"), GetTalent("Heightened Awareness"), GetTalent("Center of Being"), GetTalent("Circle of Shelter"), GetTalent("Force Protection"), GetTalent("Grit"), GetTalent("Body Guard"), GetTalent("Center of Being"), GetTalent("Force Rating"), GetTalent("Dedication"), GetTalent("Body Guard (Improved)") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Soresu Defender"), new List<Talent>() {GetTalent("Parry"), GetTalent("Parry"), GetTalent("Toughened"), GetTalent("Defensive Stance"), GetTalent("Soresu Technique"), GetTalent("Reflect"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Confidence"), GetTalent("Parry (Improved)"), GetTalent("Defensive Circle"), GetTalent("Parry"), GetTalent("Parry"), GetTalent("Reflect"), GetTalent("Reflect"), GetTalent("Defensive Stance"), GetTalent("Parry (Supreme)"), GetTalent("Dedication"), GetTalent("Reflect (Improved)"), GetTalent("Strategic Form") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Warden"), new List<Talent>() {GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Intimidating"), GetTalent("Grit"), GetTalent("Precision Strike"), GetTalent("Confidence"), GetTalent("Scathing Tirade"), GetTalent("Bad Cop"),GetTalent("Sense Advantage"), GetTalent("Confidence"), GetTalent("Fearsome"), GetTalent("No Escape"), GetTalent("Toughened"), GetTalent("Overbalance"), GetTalent("Baleful Gaze"), GetTalent("Bad Cop"), GetTalent("Grapple"), GetTalent("Dedication"), GetTalent("Force Rating"), GetTalent("Fearsome") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Warleader"), new List<Talent>() {GetTalent("Prime Positions"), GetTalent("Suppressing Fire"), GetTalent("Grit"), GetTalent("Uncanny Senses"), GetTalent("Grit"), GetTalent("Careful Planning"), GetTalent("Sense Danger"), GetTalent("Swift"),GetTalent("Suppressing Fire"), GetTalent("Grit"), GetTalent("Uncanny Senses"), GetTalent("Prescient Shot"), GetTalent("Coordinated Assault"), GetTalent("Prime Positions"), GetTalent("Blind Spot"), GetTalent("Forewarning"), GetTalent("Clever Solution"), GetTalent("Dedication"), GetTalent("Force Rating"), GetTalent("Prophetic Aim") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Advisor"), new List<Talent>() {GetTalent("Plausible Deniability"), GetTalent("Know Somebody"), GetTalent("Grit"), GetTalent("Kill with Kindness"), GetTalent("Toughened"), GetTalent("Know Somebody"), GetTalent("Knowledge is Power"), GetTalent("Nobody's Fool"),GetTalent("Grit"), GetTalent("Smooth Talker"), GetTalent("Smooth Talker"), GetTalent("Plausible Deniability"), GetTalent("Nobody's Fool"), GetTalent("Natural Charmer"), GetTalent("Contingency Plan"), GetTalent("Sense Emotions"), GetTalent("Dedication"), GetTalent("Steely Nerves"), GetTalent("Force Rating"), GetTalent("Sense Advantage") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Makashi Duelist"), new List<Talent>() {GetTalent("Grit"), GetTalent("Resist Disarm"), GetTalent("Grit"), GetTalent("Parry"), GetTalent("Parry"), GetTalent("Makashi Technique"), GetTalent("Duelist's Training"), GetTalent("Feint"),GetTalent("Parry"), GetTalent("Feint"), GetTalent("Parry"), GetTalent("Parry"), GetTalent("Intense Presence"), GetTalent("Parry (Improved)"), GetTalent("Grit"), GetTalent("Defensive Training"), GetTalent("Dedication"), GetTalent("Sum Djem"), GetTalent("Makashi Finish"), GetTalent("Makashi Flourish") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Seer"), new List<Talent>() {GetTalent("Forager"), GetTalent("Uncanny Reactions"), GetTalent("Grit"), GetTalent("Expert Tracker"), GetTalent("Rapid Reaction"), GetTalent("Keen Eyed"), GetTalent("Uncanny Reactions"), GetTalent("Toughened"),GetTalent("Sense Danger"), GetTalent("Grit"), GetTalent("Forewarning"), GetTalent("Preemptive Avoidance"), GetTalent("Force Rating"), GetTalent("Sense Advantage"), GetTalent("The Force is my Ally"), GetTalent("Dodge"), GetTalent("Rapid Reaction"), GetTalent("Toughened"), GetTalent("Natural Mystic"), GetTalent("Force Rating") }));
            talentTrees.Add(new TalentTree(GetSpecialization("mys1"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("mys2"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("mys3"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Ataru Striker"), new List<Talent>() {GetTalent("Conditioned"), GetTalent("Parry"), GetTalent("Jump Up"), GetTalent("Quick Draw"), GetTalent("Dodge"), GetTalent("Reflect"), GetTalent("Ataru Technique"), GetTalent("Quick Strike"),GetTalent("Quick Strike"), GetTalent("Reflect"), GetTalent("Parry"), GetTalent("Parry (Improved)"), GetTalent("Dodge"), GetTalent("Hawk Bat Swoop"), GetTalent("Saber Swarm"), GetTalent("Conditioned"), GetTalent("Parry"), GetTalent("Dedication"), GetTalent("Saber Throw"), GetTalent("Balance") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Executioner"), new List<Talent>() {GetTalent("Grit"), GetTalent("Quick Strike"), GetTalent("Toughened"), GetTalent("Quick Draw"), GetTalent("Mind Over Matter"), GetTalent("Hunter's Quarry"), GetTalent("Grit"), GetTalent("Lethal Blows"),GetTalent("Lethal Blows"), GetTalent("Hunter's Quarry [Improved]"), GetTalent("Quick Strike"), GetTalent("Precise Aim"), GetTalent("Terrifying Kill"), GetTalent("Precise Aim"), GetTalent("Marked for Death"), GetTalent("Deathblow"), GetTalent("Lethal Blows"), GetTalent("Essential Kill"), GetTalent("Force Rating"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Hermit"), new List<Talent>() {GetTalent("Forager"), GetTalent("Soothing Tone"), GetTalent("Grit"), GetTalent("One with Nature"), GetTalent("Conditioned"), GetTalent("Grit"), GetTalent("Menace"), GetTalent("Animal Bond"),GetTalent("Enduring"), GetTalent("Conditioned"), GetTalent("Survival of the Fittest"), GetTalent("Grit"), GetTalent("Force Rating"), GetTalent("Animal Bond (Improved)"), GetTalent("Harass"), GetTalent("Force Connection"), GetTalent("Grit"), GetTalent("Natural Outdoorsman"), GetTalent("Force Rating"), GetTalent("Shroud") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Hunter"), new List<Talent>() {GetTalent("Rapid Recovery"), GetTalent("Hunter"), GetTalent("Expert Tracker"), GetTalent("Toughened"), GetTalent("Toughened"), GetTalent("Expert Tracker"), GetTalent("Hunter"), GetTalent("Uncanny Senses"),GetTalent("Side Step"), GetTalent("Keen Eyed"), GetTalent("Natural Hunter"), GetTalent("Uncanny Reactions"), GetTalent("Rapid Recovery"), GetTalent("Soft Spot"), GetTalent("Sixth Sense"), GetTalent("Rapid Recovery"), GetTalent("Side Step"), GetTalent("Dedication"), GetTalent("Intuitive Shot"), GetTalent("Force Rating") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Navigator"), new List<Talent>() {GetTalent("Studious Plotting"), GetTalent("Expert Tracker"), GetTalent("Shortcut"), GetTalent("Grit"), GetTalent("Galaxy Mapper"), GetTalent("Shortcut (Improved)"), GetTalent("Planet Mapper"), GetTalent("Preemptive Avoidance"),GetTalent("Shortcut"), GetTalent("Swift"), GetTalent("Uncanny Senses"), GetTalent("Toughened"), GetTalent("Galaxy Mapper"), GetTalent("Holistic Navigation"), GetTalent("Force Rating"), GetTalent("Planet Mapper"), GetTalent("One With the Universe"), GetTalent("Intuitive Navigation"), GetTalent("Master Starhopper"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Pathfinder"), new List<Talent>() {GetTalent("Grit"), GetTalent("Keen Eyed"), GetTalent("Forager"), GetTalent("Swift"), GetTalent("Keen Eyed"), GetTalent("Outdoorsman"), GetTalent("Toughened"), GetTalent("Outdoorsman"), GetTalent("Animal Empathy"), GetTalent("Animal Bond"), GetTalent("Grit"), GetTalent("Sleight of Mind"), GetTalent("Mental Bond"), GetTalent("Force Rating"), GetTalent("Quick Movement"), GetTalent("Toughened"), GetTalent("Share Pain"), GetTalent("Enduring"), GetTalent("Natural Outdoorsman"), GetTalent("Dedication") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Artisan"), new List<Talent>() {GetTalent("Solid Repairs"), GetTalent("Fine Tuning"), GetTalent("Mental Tools"), GetTalent("Technical Aptitude"), GetTalent("Grit"), GetTalent("Solid Repairs"), GetTalent("Fine Tuning"), GetTalent("Grit"),GetTalent("Inventor"), GetTalent("Imbue Item"), GetTalent("Natural Tinkerer"), GetTalent("Defensive Slicing"), GetTalent("Solid Repairs"), GetTalent("Force Rating"), GetTalent("Defensive Slicing"), GetTalent("Mental Fortress"), GetTalent("Master Artisan"), GetTalent("Intuitive Improvements"), GetTalent("Dedication"), GetTalent("Comprehend Technology") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Investigator"), new List<Talent>() {GetTalent("Street Smarts"), GetTalent("Keen Eyed"), GetTalent("Uncanny Senses"), GetTalent("Grit"), GetTalent("Talk the Talk"), GetTalent("Grit"), GetTalent("Street Smarts"), GetTalent("Toughened"),GetTalent("Toughened"), GetTalent("Keen Eyed"), GetTalent("Street Smarts"), GetTalent("Reconstruct the Scene"), GetTalent("Sense Advantage"), GetTalent("Unrelenting Skeptic"), GetTalent("Clever Solution"), GetTalent("Sense the Scene"), GetTalent("Valuable Facts"), GetTalent("Dedication"), GetTalent("Street Smarts (Improved)"), GetTalent("Force Rating") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Racer"), new List<Talent>() {GetTalent("Grit"), GetTalent("Skilled Jockey"), GetTalent("Conditioned"), GetTalent("Shortcut"), GetTalent("Shortcut"), GetTalent("Full Throttle"), GetTalent("Shortcut"), GetTalent("Conditioned"),GetTalent("Skilled Jockey"), GetTalent("Full Throttle [Improved]"), GetTalent("Freerunning"), GetTalent("Freerunning (Improved)"), GetTalent("Grit"), GetTalent("Full Throttle [Supreme]"), GetTalent("Force Rating"), GetTalent("Better Luck Next Time"), GetTalent("Superhuman Reflexes"), GetTalent("Dedication"), GetTalent("Shortcut (Improved)"), GetTalent("Intuitive Evasion") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Sentry"), new List<Talent>() {GetTalent("Toughened"), GetTalent("Reflect"), GetTalent("Grit"), GetTalent("Conditioned"), GetTalent("Uncanny Reactions"), GetTalent("Grit"), GetTalent("Reflect"), GetTalent("Uncanny Reactions"),GetTalent("Sleight of Mind"), GetTalent("Saber Throw (Improved)"), GetTalent("Saber Throw"), GetTalent("Impossible Fall"), GetTalent("Dodge"), GetTalent("Fear the Shadows"), GetTalent("Constant Vigilance"), GetTalent("Sleight of Mind"), GetTalent("Force Rating"), GetTalent("Reflect (Improved)"), GetTalent("Dodge"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Shadow"), new List<Talent>() {GetTalent("Sleight of Mind"), GetTalent("Street Smarts"), GetTalent("Codebreaker"), GetTalent("Indistinguishable"), GetTalent("Well Rounded"), GetTalent("Mental Fortress"), GetTalent("Grit"), GetTalent("Indistinguishable"),GetTalent("Shroud"), GetTalent("Dodge"), GetTalent("Sleight of Mind"), GetTalent("Grit"), GetTalent("Slippery Minded"), GetTalent("Codebreaker"), GetTalent("Now You See Me"), GetTalent("Dodge"), GetTalent("Force Rating"), GetTalent("Anatomy Lessons"), GetTalent("Master of Shadows"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Shien Expert"), new List<Talent>() {GetTalent("Side Step"), GetTalent("Conditioned"), GetTalent("Street Smarts"), GetTalent("Reflect"), GetTalent("Toughened"), GetTalent("Parry"), GetTalent("Shien Technique"), GetTalent("Reflect"),GetTalent("Parry"), GetTalent("Counterstrike"), GetTalent("Grit"), GetTalent("Reflect (Improved)"), GetTalent("Djem So Deflection"), GetTalent("Defensive Stance"), GetTalent("Saber Throw"), GetTalent("Reflect"), GetTalent("Falling Avalanche"), GetTalent("Dedication"), GetTalent("Disruptive Strike"), GetTalent("Reflect (Supreme)") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Aggressor"), new List<Talent>() {GetTalent("Intimidating"), GetTalent("Plausible Deniability"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Fearsome"), GetTalent("Intimidating"), GetTalent("Prey on the Weak"), GetTalent("Sense Advantage"),GetTalent("Fearsome"), GetTalent("Terrify"), GetTalent("Crippling Blow"), GetTalent("Toughened"), GetTalent("Grit"), GetTalent("Terrify (Improved)"), GetTalent("Prey on the Weak"), GetTalent("Heroic Fortitude"), GetTalent("Force Rating"), GetTalent("Fearsome"), GetTalent("Dedication"), GetTalent("Against all Odds") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Shii-Cho Knight"), new List<Talent>() {GetTalent("Parry"), GetTalent("Second Wind"), GetTalent("Toughened"), GetTalent("Parry"), GetTalent("Second Wind"), GetTalent("Conditioned"), GetTalent("Multiple Opponents"), GetTalent("Durable"),GetTalent("Quick Draw"), GetTalent("Grit"), GetTalent("Parry"), GetTalent("Defensive Training"), GetTalent("Natural Blademaster"), GetTalent("Sarlacc Sweep"), GetTalent("Parry (Improved)"), GetTalent("Sum Djem"), GetTalent("Center of Being"), GetTalent("Durable"), GetTalent("Dedication"), GetTalent("Parry") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Starfighter Ace"), new List<Talent>() {GetTalent("Grit"), GetTalent("Skilled Jockey"), GetTalent("Rapid Reaction"), GetTalent("Solid Repairs"), GetTalent("Intuitive Evasion"), GetTalent("Confidence"), GetTalent("Solid Repairs"), GetTalent("Galaxy Mapper"),GetTalent("Full Throttle"), GetTalent("Rapid Reaction"), GetTalent("Exhaust Port"), GetTalent("Grit"), GetTalent("Intuitive Strike"), GetTalent("Touch of Fate"), GetTalent("Grit"), GetTalent("Skilled Jockey"), GetTalent("Force Rating"), GetTalent("Tricky Target"), GetTalent("Dedication"), GetTalent("Intuitive Evasion") }));
            talentTrees.Add(new TalentTree(GetSpecialization("war1"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("war2"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));
            talentTrees.Add(new TalentTree(GetSpecialization("war3"), new List<Talent>() {GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"),GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit"), GetTalent("Grit") }));

            talentTrees.Add(new TalentTree(GetSpecialization("Force-Sensitive Exile"), new List<Talent>() {GetTalent("Uncanny Senses"), GetTalent("Insight"), GetTalent("Forager"), GetTalent("Uncanny Reactions"), GetTalent("Convincing Demeanor"), GetTalent("Overwhelm Emotions"), GetTalent("Intense Focus"), GetTalent("Quick Draw"),GetTalent("Sense Danger"), GetTalent("Sense Emotions"), GetTalent("Balance"), GetTalent("Touch of Fate"), GetTalent("Street Smarts"), GetTalent("Uncanny Senses"), GetTalent("Uncanny Reactions"), GetTalent("Street Smarts"), GetTalent("Sixth Sense"), GetTalent("Force Rating"), GetTalent("Dedication"), GetTalent("Superior Reflexes") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Force-Sensitive Emergent"), new List<Talent>() {GetTalent("Insight"), GetTalent("Uncanny Senses"), GetTalent("Indistinguishable"), GetTalent("Grit"), GetTalent("Uncanny Reactions"), GetTalent("Toughened"), GetTalent("Sleight of Mind"), GetTalent("Sleight of Mind"),GetTalent("Uncanny Senses"), GetTalent("Uncanny Reactions"), GetTalent("Grit"), GetTalent("Indistinguishable"), GetTalent("Toughened"), GetTalent("Sense Danger"), GetTalent("Touch of Fate"), GetTalent("Balance"), GetTalent("Invigorate"), GetTalent("Force of Will"), GetTalent("Force Rating"), GetTalent("Dedication") }));
            talentTrees.Add(new TalentTree(GetSpecialization("Recruit"), new List<Talent>() {GetTalent("Basic Combat Training"), GetTalent("Second Wind"), GetTalent("Outdoorsman"), GetTalent("Tactical Combat Training"), GetTalent("Second Wind"), GetTalent("Vehicle Combat Training"), GetTalent("Well Traveled"), GetTalent("Toughened"),GetTalent("Quick Draw"), GetTalent("Grit"), GetTalent("Toughened"), GetTalent("Spare Clip"), GetTalent("Second Wind"), GetTalent("Jump Up"), GetTalent("Grit"), GetTalent("Creative Killer"), GetTalent("Dynamic Fire"), GetTalent("Dedication"), GetTalent("Toughened"), GetTalent("Enduring") }));
            return talentTrees;
        }

        private IList<Skill> GetSkills(IList<string> skillNames)
        {
            IList<Skill> result = new List<Skill>();
            foreach (string skillName  in skillNames)
            {
                Skill skill = skills.First<Skill>(x => x.Name.Equals(skillName));
                result.Add(skill);
            }

            return result;
        }

        private IList<Skill> GetSkillsForSpecialization(Specialization specialization)
        {
            IList<Skill> result;
            switch (specialization.SpecializationName)
            {
                case "Assassin":
                    result = GetSkills(new List<string>() { "Skulduggery", "Stealth", "Melee", "Ranged Heavy" });
                    break;
                case "Gadgeteer":
                    result = GetSkills(new List<string>() { "Coercion", "Mechanics", "Brawl", "Ranged Light" });
                    break;
                case "Martial Artist":
                    result = GetSkills(new List<string>() { "Athletics", "Coordination", "Discipline", "Brawl" });
                    break;
                case "Operator":
                    result = GetSkills(new List<string>() { "Astrogation", "Piloting Planetary", "Piloting Space", "Gunnery" });
                    break;
                case "Skip Tracer":
                    result = GetSkills(new List<string>() { "Cool", "Negotiation", "Skulduggery", "Underworld" });
                    break;
                case "Survivalist":
                    result = GetSkills(new List<string>() { "Perception", "Resilience", "Survival", "Xenology" });
                    break;

                case "Doctor":
                    result = GetSkills(new List<string>() { "Cool", "Medicine", "Resilience", "Education" });
                    break;
                case "Entrepreneur":
                    result = GetSkills(new List<string>() { "Discipline", "Negotiation", "Education", "Underworld" });
                    break;
                case "Marshal":
                    result = GetSkills(new List<string>() { "Coercion", "Vigilance", "Underworld", "Ranged Light" });
                    break;
                case "Performer":
                    result = GetSkills(new List<string>() { "Charm", "Coordination", "Deception", "Melee" });
                    break;
                case "Politico":
                    result = GetSkills(new List<string>() { "Charm", "Coercion", "Deception", "Core Worlds" });
                    break;
                case "Scholar":
                    result = GetSkills(new List<string>() { "Perception", "Outer Rim", "Underworld", "Xenology" });
                    break;

                case "Archaeologist":
                    result = GetSkills(new List<string>() { "Athletics", "Discipline", "Education", "Lore" });
                    break;
                case "Big-Game Hunter":
                    result = GetSkills(new List<string>() { "Stealth", "Survival", "Xenology", "Ranged Heavy" });
                    break;
                case "Driver":
                    result = GetSkills(new List<string>() { "Cool", "Mechanics", "Piloting Planetary", "Gunnery" });
                    break;
                case "Fringer":
                    result = GetSkills(new List<string>() { "Astrogation", "Coordination", "Negotiation", "Streetwise" });
                    break;
                case "Scout":
                    result = GetSkills(new List<string>() { "Athletics", "Medicine", "Piloting Planetary", "Survival" });
                    break;
                case "Trader":
                    result = GetSkills(new List<string>() { "Deception", "Negotiation", "Core Worlds", "Underworld" });
                    break;

                case "Bodyguard":
                    result = GetSkills(new List<string>() { "Perception", "Piloting Planetary", "Gunnery", "Ranged Heavy" });
                    break;
                case "Demolitionist":
                    result = GetSkills(new List<string>() { "Computers", "Cool", "Mechanics", "Skulduggery" });
                    break;
                case "Enforcer":
                    result = GetSkills(new List<string>() { "Coercion", "Streetwise", "Underworld", "Brawl" });
                    break;
                case "Heavy":
                    result = GetSkills(new List<string>() { "Perception", "Resilience", "Gunnery", "Ranged Heavy" });
                    break;
                case "Marauder":
                    result = GetSkills(new List<string>() { "Coercion", "Resilience", "Survival", "Melee" });
                    break;
                case "Mercenary Soldier":
                    result = GetSkills(new List<string>() { "Discipline", "Leadership", "Gunnery", "Ranged Heavy" });
                    break;

                case "Charmer":
                    result = GetSkills(new List<string>() { "Charm", "Cool", "Leadership", "Negotiation" });
                    break;
                case "Gambler":
                    result = GetSkills(new List<string>() { "Computers", "Cool", "Deception", "Skulduggery" });
                    break;
                case "Gunslinger":
                    result = GetSkills(new List<string>() { "Coercion", "Cool", "Outer Rim", "Ranged Light" });
                    break;
                case "Pilot":
                    result = GetSkills(new List<string>() { "Astrogation", "Piloting Planetary", "Piloting Space", "Gunnery" });
                    break;
                case "Scoundrel":
                    result = GetSkills(new List<string>() { "Charm", "Cool", "Deception", "Ranged Light" });
                    break;
                case "Thief":
                    result = GetSkills(new List<string>() { "Computers", "Skulduggery", "Stealth", "Vigilance" });
                    break;

                case "Cyber Tech":
                    result = GetSkills(new List<string>() { "Athletics", "Mechanics", "Medicine", "Vigilance" });
                    break;
                case "Droid Tech":
                    result = GetSkills(new List<string>() { "Computers", "Cool", "Mechanics", "Leadership" });
                    break;
                case "Mechanic":
                    result = GetSkills(new List<string>() { "Mechanics", "Piloting Space", "Skulduggery", "Brawl" });
                    break;
                case "Modder":
                    result = GetSkills(new List<string>() { "Mechanics", "Piloting Space", "Streetwise", "Gunnery" });
                    break;
                case "Outlaw Tech":
                    result = GetSkills(new List<string>() { "Mechanics", "Streetwise", "Education", "Underworld" });
                    break;
                case "Slicer":
                    result = GetSkills(new List<string>() { "Computers", "Stealth", "Education", "Underworld" });
                    break;

                case "Beast Rider":
                    result = GetSkills(new List<string>() { "Athletics", "Perception", "Survival", "Xenology" });
                    break;
                case "Driver Ace":
                    result = GetSkills(new List<string>() { "Cool", "Mechanics", "Piloting Planetary", "Gunnery" });
                    break;
                case "Gunner":
                    result = GetSkills(new List<string>() { "Discipline", "Resilience", "Gunnery", "Ranged Heavy" });
                    break;
                case "Hotshot":
                    result = GetSkills(new List<string>() { "Cool", "Coordination", "Piloting Planetary", "Piloting Space" });
                    break;
                case "Pilot Ace":
                    result = GetSkills(new List<string>() { "Astrogation", "Piloting Planetary", "Piloting Space", "Gunnery" });
                    break;
                case "Rigger":
                    result = GetSkills(new List<string>() { "Mechanics", "Resilience", "Underworld", "Gunnery" });
                    break;

                case "Commodore":
                    result = GetSkills(new List<string>() { "Astrogation", "Computers", "Education", "Outer Rim" });
                    break;
                case "Figurehead":
                    result = GetSkills(new List<string>() { "Cool", "Leadership", "Negotiation", "Core Worlds" });
                    break;
                case "Instructor":
                    result = GetSkills(new List<string>() { "Discipline", "Medicine", "Education", "Ranged Heavy" });
                    break;
                case "Squadron Leader":
                    result = GetSkills(new List<string>() { "Mechanics", "Piloting Planetary", "Piloting Space", "Gunnery" });
                    break;
                case "Strategist":
                    result = GetSkills(new List<string>() { "Computers", "Cool", "Vigilance", "Warfare" });
                    break;
                case "Tactician":
                    result = GetSkills(new List<string>() { "Discipline", "Leadership", "Brawl", "Ranged Heavy" });
                    break;

                case "Advocate":
                    result = GetSkills(new List<string>() { "Coercion", "Deception", "Negotiation", "Vigilance" });
                    break;
                case "Agitator":
                    result = GetSkills(new List<string>() { "Coercion", "Deception", "Streetwise", "Underworld" });
                    break;
                case "Ambassador":
                    result = GetSkills(new List<string>() { "Charm", "Discipline", "Negotiation", "Core Worlds"});
                    break;
                case "Analyst":
                    result = GetSkills(new List<string>() { "Computers", "Perception", "Education", "Warfare" });
                    break;
                case "Propagandist":
                    result = GetSkills(new List<string>() { "Charm", "Deception", "Perception", "Warfare" });
                    break;
                case "Quartermaster":
                    result = GetSkills(new List<string>() { "Computers", "Negotiation", "Skulduggery", "Vigilance" });
                    break;

                case "Mechanic Engineer":
                    result = GetSkills(new List<string>() { "Mechanics", "Piloting Space", "Skulduggery", "Brawl" });
                    break;
                case "Saboteur":
                    result = GetSkills(new List<string>() { "Coordination", "Mechanics", "Skulduggery", "Stealth" });
                    break;
                case "Scientist":
                    result = GetSkills(new List<string>() { "Computers", "Medicine", "Education", "Lore" });
                    break;
                case "eng1":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "eng2":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "eng3":
                    result = GetSkills(new List<string>() {  });
                    break;

                case "Commando":
                    result = GetSkills(new List<string>() { "Resilience", "Survival", "Brawl", "Melee" });
                    break;
                case "Heavy Soldier":
                    result = GetSkills(new List<string>() { "Perception", "Resilience", "Gunnery", "Ranged Heavy" });
                    break;
                case "Medic":
                    result = GetSkills(new List<string>() { "Medicine", "Resilience", "Vigilance", "Xenology" });
                    break;
                case "Sharpshooter":
                    result = GetSkills(new List<string>() { "Cool", "Perception", "Ranged Light", "Ranged Heavy" });
                    break;
                case "Trailblazer":
                    result = GetSkills(new List<string>() { "Perception", "Stealth", "Survival", "Outer Rim" });
                    break;
                case "Vanguard":
                    result = GetSkills(new List<string>() { "Athletics", "Cool", "Vigilance", "Resilience" });
                    break;

                case "Infiltrator":
                    result = GetSkills(new List<string>() { "Deception", "Skulduggery", "Streetwise", "Melee" });
                    break;
                case "Scout Spy":
                    result = GetSkills(new List<string>() { "Athletics", "Medicine", "Survival", "Piloting Planetary" });
                    break;
                case "Slicer Spy":
                    result = GetSkills(new List<string>() { "Computers", "Stealth", "Education", "Underworld" });
                    break;
                case "spy1":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "spy2":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "spy3":
                    result = GetSkills(new List<string>() {  });
                    break;

                case "Healer":
                    result = GetSkills(new List<string>() { "Discipline", "Medicine", "Education", "Xenology" });
                    break;
                case "Niman Disciple":
                    result = GetSkills(new List<string>() { "Discipline", "Leadership", "Negotiation", "Lightsaber" });
                    break;
                case "Sage":
                    result = GetSkills(new List<string>() { "Astrogation", "Charm", "Cool", "Lore" });
                    break;
                case "con1":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "con2":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "con3":
                    result = GetSkills(new List<string>() {  });
                    break;

                case "Armorer":
                    result = GetSkills(new List<string>() { "Mechanics", "Resilience", "Outer Rim", "Lightsaber" });
                    break;
                case "Peacekeeper":
                    result = GetSkills(new List<string>() { "Discipline", "Leadership", "Perception", "Piloting Planetary" });
                    break;
                case "Protector":
                    result = GetSkills(new List<string>() { "Athletics", "Medicine", "Resilience", "Ranged Light" });
                    break;
                case "Soresu Defender":
                    result = GetSkills(new List<string>() { "Discipline", "Vigilance", "Lore", "Lightsaber" });
                    break;
                case "Warden":
                    result = GetSkills(new List<string>() { "Coercion", "Discipline", "Underworld", "Brawl" });
                    break;
                case "Warleader":
                    result = GetSkills(new List<string>() { "Leadership", "Perception", "Survival", "Ranged Light" });
                    break;

                case "Advisor":
                    result = GetSkills(new List<string>() { "Charm", "Deception", "Negotiation", "Streetwise" });
                    break;
                case "Makashi Duelist":
                    result = GetSkills(new List<string>() { "Charm", "Cool", "Coordination", "Lightsaber" });
                    break;
                case "Seer":
                    result = GetSkills(new List<string>() { "Discipline", "Survival",  "Vigilance", "Lore"});
                    break;
                case "mys1":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "mys2":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "mys3":
                    result = GetSkills(new List<string>() {  });
                    break;

                case "Ataru Striker":
                    result = GetSkills(new List<string>() { "Athletics", "Coordination", "Perception", "Lightsaber" });
                    break;
                case "Executioner":
                    result = GetSkills(new List<string>() { "Discipline", "Perception", "Melee", "Ranged Heavy" });
                    break;
                case "Hermit":
                    result = GetSkills(new List<string>() { "Discipline", "Stealth", "Survival", "Xenology" });
                    break;
                case "Hunter":
                    result = GetSkills(new List<string>() { "Coordination", "Stealth", "Vigilance", "Ranged Heavy" });
                    break;
                case "Navigator":
                    result = GetSkills(new List<string>() { "Astrogation", "Perception", "Survival", "Outer Rim" });
                    break;
                case "Pathfinder":
                    result = GetSkills(new List<string>() { "Medicine", "Resilience", "Survival", "Ranged Light" });
                    break;

                case "Artisan":
                    result = GetSkills(new List<string>() { "Astrogation", "Computers", "Mechanics", "Education" });
                    break;
                case "Investigator":
                    result = GetSkills(new List<string>() { "Perception", "Streetwise", "Education", "Underworld" });
                    break;
                case "Racer":
                    result = GetSkills(new List<string>() { "Cool", "Coordination", "Piloting Planetary", "Piloting Space" });
                    break;
                case "Sentry":
                    result = GetSkills(new List<string>() { "Coordination", "Stealth", "Vigilance", "Lightsaber" });
                    break;
                case "Shadow":
                    result = GetSkills(new List<string>() { "Skulduggery", "Stealth", "Streetwise", "Underworld" });
                    break;
                case "Shien Expert":
                    result = GetSkills(new List<string>() { "Athletics", "Resilience", "Skulduggery", "Lightsaber" });
                    break;

                case "Aggressor":
                    result = GetSkills(new List<string>() { "Coercion", "Streetwise", "Underworld", "Ranged Light" });
                    break;
                case "Shii-Cho Knight":
                    result = GetSkills(new List<string>() { "Athletics", "Coordination", "Lightsaber", "Melee" });
                    break;
                case "Starfighter Ace":
                    result = GetSkills(new List<string>() { "Astrogation", "Mechanics", "Piloting Space", "Gunnery" });
                    break;
                case "war1":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "war2":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "war3":
                    result = GetSkills(new List<string>() {  });
                    break;

                case "Force-Sensitive Exile":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "Force-Sensitive Emergent":
                    result = GetSkills(new List<string>() {  });
                    break;
                case "Recruit":
                    result = GetSkills(new List<string>() { "Athletics", "Discipline", "Survival", "Vigilance" });
                    break;
                default:
                    throw new System.Exception("Unknown specialization " + specialization.SpecializationName);
            }

            return result;
        }

        private IList<Skill> GetSkillsForCareer(Career career)
        {
            IList<Skill> result;
            switch(career.CareerName)
            {
                case "Bounty Hunter":
                    result = GetSkills(new List<string>() { "Athletics", "Perception", "Piloting Planetary", "Piloting Space", "Streetwise", "Vigilance", "Brawl", "Ranged Heavy" });
                    break;
                case "Colonist" :
                    result = GetSkills(new List<string>() { "Charm", "Deception", "Leadership", "Negotiation", "Streetwise", "Core Worlds", "Education", "Lore" });
                    break;
                case "Explorer":
                    result = GetSkills(new List<string>() { "Astrogation", "Cool", "Perception", "Piloting Space", "Survival", "Lore", "Outer Rim", "Xenology" });
                    break;
                case "Hired Gun":
                    result = GetSkills(new List<string>() { "Athletics", "Discipline", "Piloting Planetary", "Resilience", "Vigilance", "Brawl", "Melee", "Ranged Light" });
                    break;
                case "Smuggler":
                    result = GetSkills(new List<string>() { "Coordination", "Deception", "Perception", "Piloting Space", "Skulduggery", "Streetwise", "Vigilance", "Underworld" });
                    break;
                case "Technician":
                    result = GetSkills(new List<string>() { "Astrogation", "Computers", "Coordination", "Discipline", "Mechanics", "Perception", "Piloting Planetary", "Outer Rim" });
                    break;
                case "Ace":
                    result = GetSkills(new List<string>() { "Astrogation", "Cool", "Mechanics", "Perception", "Piloting Planetary", "Piloting Space", "Gunnery", "Ranged Light" });
                    break;
                case "Commander":
                    result = GetSkills(new List<string>() { "Coercion", "Cool", "Discipline", "Leadership", "Perception", "Vigilance", "Warfare", "Ranged Light" });
                    break;
                case "Diplomat":
                    result = GetSkills(new List<string>() { "Charm", "Deception", "Leadership", "Negotiation", "Core Worlds", "Lore", "Outer Rim", "Xenology" });
                    break;
                case "Engineer":
                    result = GetSkills(new List<string>() { "Athletics", "Computers", "Mechanics", "Perception", "Piloting Space", "Vigilance", "Education", "Ranged Light" });
                    break;
                case "Soldier":
                    result = GetSkills(new List<string>() { "Athletics", "Medicine", "Survival", "Warfare", "Brawl", "Melee", "Ranged Light", "Ranged Heavy" });
                    break;
                case "Spy":
                    result = GetSkills(new List<string>() { "Computers", "Cool", "Coordination", "Deception", "Perception", "Skulduggery", "Stealth", "Warfare" });
                    break;
                case "Consular":
                    result = GetSkills(new List<string>() { "Cool", "Discipline", "Leadership", "Negotiation", "Education", "Lore"});
                    break;
                case "Guardian":
                    result = GetSkills(new List<string>() { "Cool", "Discipline", "Resilience", "Vigilance", "Brawl", "Melee"});
                    break;
                case "Mystic":
                    result = GetSkills(new List<string>() { "Charm", "Coercion", "Perception", "Vigilance", "Lore", "Outer Rim"});
                    break;
                case "Seeker":
                    result = GetSkills(new List<string>() { "Piloting Planetary", "Piloting Space", "Survival", "Vigilance", "Xenology", "Ranged Heavy" });
                    break;
                case "Sentinel":
                    result = GetSkills(new List<string>() { "Computers", "Deception", "Perception", "Skulduggery", "Stealth", "Core Worlds"});
                    break;
                case "Warrior":
                    result = GetSkills(new List<string>() { "Athletics", "Cool", "Perception", "Survival", "Brawl", "Melee" });
                    break;
                case "Universal":
                    result = new List<Skill>();
                    break;
                default:
                    throw new System.Exception("Unknown careerId " + career.CareerId);
            }

            return result;
        }
        
             
              
        public IList<Career> GetCarreers()
        {
            return careers;
        }

        
        public IList<Skill> GetCareerSkills(Career career)
        {
            return careerSkills[career];
        }

        public IList<Specialization> GetCareerSpecializations(Career career)
        {
            return specializations.Where(x => x.Career.Equals(career)).ToList<Specialization>();
        }

        IEnumerable<Specialization> IStaticDataRepository.GetCareerSpecializations(Career theCareer)
        {
            return specializations.Where(x => x.Career.Equals(theCareer));
        }

        public IList<Specialization> GetSpecializations()
        {
            return specializations;
        }

        public Specialization GetSpecialization(string specializationName)
        {
            if (string.IsNullOrEmpty(specializationName)) throw new System.Exception("No specialization found");
            return specializations.First<Specialization>(x => x.SpecializationName.Equals(specializationName));
        }
        

        public Talent GetTalent(string talentName)
        {
            if (string.IsNullOrEmpty(talentName)) throw new System.Exception("No talent found");
            return talents.First<Talent>(x => x.TalentName.Equals(talentName));
        }
        

        public IList<Skill> GetSpecializationSkills(Specialization specialization)
        {
            return specializationSkills[specialization];
        }

        public TalentTree GetSpecializationTalentTree(Specialization specialization)
        {
            return talentTrees.First<TalentTree>(x => x.Specialization == specialization);
        }

        public IList<Talent> GetTalents()
        {
            return talents;
        }

        public IList<Skill> GetSkills()
        {
            return skills;
        }

        public IList<TalentTree> GetTalentTrees()
        {
            return talentTrees;
        }

        public IList<Specialization> GetSpecializationsWithTalent(Talent talent)
        {
            IList<Specialization> result = new List<Specialization>();
            foreach (var talentTree in talentTrees)
            {
                if (talentTree.HasTalent(talent))
                {
                    result.Add(talentTree.Specialization);
                }
            }

            return result;
        }
    }
}
