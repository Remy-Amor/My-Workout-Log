namespace MyWorkoutLog;

public class BaseExercises
{
    // Basic strength exercises
    private Exercise benchPress = new Exercise(
        name: "Barbell Bench Press",
        note: "Focus on chest contraction",
        reps: 8,
        weight: 185f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.barbell
    );

    private Exercise squat = new Exercise(
        name: "Back Squat",
        note: "Keep chest up and back straight",
        reps: 6,
        weight: 225f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.barbell
    );

    private Exercise deadlift = new Exercise(
        name: "Conventional Deadlift",
        note: "Drive through heels, lock hips at top",
        reps: 5,
        weight: 275f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.barbell
    );

    // Dumbbell exercises
    private Exercise shoulderPress = new Exercise(
        name: "Dumbbell Shoulder Press",
        note: "Seated position, full range of motion",
        reps: 10,
        weight: 45f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.dumbbells
    );

    private Exercise bicepCurls = new Exercise(
        name: "Dumbbell Bicep Curls",
        note: "Alternating arms, no swinging",
        reps: 12,
        weight: 25f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.dumbbells
    );

    // Machine exercises
    private Exercise legPress = new Exercise(
        name: "Leg Press",
        note: "Don't lock knees at top",
        reps: 15,
        weight: 360f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.machine
    );

    private Exercise latPulldown = new Exercise(
        name: "Lat Pulldown",
        note: "Pull to chest, squeeze back",
        reps: 10,
        weight: 120f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.machine
    );

    // Cable machine exercises
    private Exercise tricepPushdown = new Exercise(
        name: "Cable Tricep Pushdown",
        note: "Rope attachment, elbows tucked",
        reps: 12,
        weight: 50f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.cablemachine
    );

    private Exercise cableCrossover = new Exercise(
        name: "Cable Crossover",
        note: "Upper chest focus",
        reps: 15,
        weight: 40f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.cablemachine
    );

    // Resistance band exercises
    private Exercise bandPullApart = new Exercise(
        name: "Resistance Band Pull Apart",
        note: "Shoulder health exercise",
        reps: 20,
        weight: 0f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.resistanceband
    );

    // Imperial system examples 
    private Exercise imperialSquat = new Exercise(
        name: "Back Squat",
        note: "ATG - Ass to Grass",
        reps: 8,
        weight: 100f,
        weightunits: WeightUnit.LB,  
        equipment: EquipmentType.barbell
    );

    private Exercise imperialBench = new Exercise(
        name: "Bench Press",
        note: "Pause at chest",
        reps: 5,
        weight: 80f,
        weightunits: WeightUnit.LB,  
        equipment: EquipmentType.barbell
    );

    // Other equipment type
    private Exercise kettlebellSwing = new Exercise(
        name: "Kettlebell Swing",
        note: "Hip hinge movement",
        reps: 20,
        weight: 24f,
        weightunits: WeightUnit.LB,  
        equipment: EquipmentType.other
    );

    private Exercise bodyweightPullup = new Exercise(
        name: "Pull-ups",
        note: "Bodyweight only",
        reps: 8,
        weight: 0f,
        weightunits: WeightUnit.KG,  
        equipment: EquipmentType.other
    );

    private readonly List<Exercise> exercises;

    public BaseExercises()
    {
        exercises = new List<Exercise>
            {
                benchPress,
                squat,
                shoulderPress,
                legPress,
                tricepPushdown,
                bandPullApart,
                imperialSquat,
                bodyweightPullup,
                kettlebellSwing,
                imperialBench,
                cableCrossover,
                latPulldown,
                bicepCurls,
                deadlift,
            };
    }

    public List<Exercise> List => exercises;

}