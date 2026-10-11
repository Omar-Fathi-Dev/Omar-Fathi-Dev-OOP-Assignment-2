using System.Runtime.Intrinsics.Arm;
using SrpLab;
using CheckoutBasket = SrpLab.CheckoutBasket;

//Appointment

Console.WriteLine("SrpLab — 10 intentional SRP violations (refactor me)");
Console.WriteLine("=================================================");

var beds   = new BedAssignments();
var scorer = new AcuityScorer();
var pager  = new PagerDispatcher();
var note   = new HandoffNoteWriter();

var acuity = scorer.Score(heartRate: 130, spo2: 89);
beds.Assign(1, "p-88", acuity);
pager.Consider(1, acuity, DateTime.UtcNow);

Console.WriteLine(note.Write(1, beds.Find(1), DateTime.UtcNow));
Console.WriteLine(string.Join(" | ", pager.DrainLog()));

Console.WriteLine("-----------------------------------------------------------");

var basket = new CheckoutBasket();
PaymentAuthStub paymentAuth = new PaymentAuthStub();

basket.AddLine("SKU-1", 40m, 2);
basket.ApplyCouponText("SAVE10");
basket.EnableGiftWrap();
Console.WriteLine($"basket total={basket.GrandTotal()} auth={paymentAuth.Authorize(
    basket.GrandTotal(),
    "4242",
    basket.LineCount) }");

Console.WriteLine("-----------------------------------------------------------");

var ticket   = new SupportTicket("T-1", "cannot login", "prod is down for me", DateTimeOffset.UtcNow);
var sla      = new SlaPolicy();
var deadline = sla.Deadline(ticket.Priority, ticket.OpenedAt);

Console.WriteLine(new PublicReplyDrafter().Draft(ticket.Id, ticket.Priority, "Nora", deadline));

Console.WriteLine("-----------------------------------------------------------");


var app       = new LoanApplication(60_000m, 640, 4, HasCollateral: false);
var assessor  = new LoanRiskAssessor();
var checklist = new RequiredDocumentsChecklist();
var l    = new LoanDecisionLetterWriter();
var eligible = assessor.IsEligible(app);
var risk     = assessor.RiskScore(app);
var docs     = checklist.For(app, eligible);
Console.WriteLine(l.Write("Omar", app.RequestedAmount, eligible, risk, docs));

Console.WriteLine("-----------------------------------------------------------");

var courseRoster = new CourseRoster(1);
WelcomePacketMarkdownWriter welcomePacketMarkdownWriter = new WelcomePacketMarkdownWriter();
Console.WriteLine(courseRoster.Register("a@mail.com"));
Console.WriteLine(courseRoster.Register("b@mail.com"));
Console.WriteLine(
    welcomePacketMarkdownWriter.Write(
        "SEF-101",
        "Bea",
        courseRoster.IsSeated("b@mail.com"),
        courseRoster.WaitlistPosition("b@mail.com"))
);

Console.WriteLine("-----------------------------------------------------------");

var kitchenTicket = new KitchenTicket();
ThermalTicketPrinter printer = new ThermalTicketPrinter();
AllergenDetector allergenDetector = new AllergenDetector();
CookTimeEstimator cookTimeEstimator = new CookTimeEstimator();
int etaMinutes = cookTimeEstimator.EstimatedReadyMinutes(kitchenTicket.Items,
    2,
    allergenDetector.Detect(kitchenTicket.Items).Count > 0);

kitchenTicket.AddItem("Pasta", new[] { "wheat", "milk" }, 12);
Console.WriteLine(printer.RenderThermalTicket(
    42,
    kitchenTicket.Items,
    allergenDetector.Detect(kitchenTicket.Items),
    etaMinutes
    ));

Console.WriteLine("-----------------------------------------------------------");

var terms     = new SubscriptionTerms("c-9", 99m, new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 1));
var proration = new ProrationCalculator();
var numbers   = new InvoiceNumberGenerator();
var failures  = new FailedPaymentTracker();
var dunning   = new DunningEmailWriter();

failures.Register();

var amount  = proration.Prorate(terms, terms.PeriodStart);
var invoice = numbers.Next(terms.PeriodStart);
Console.WriteLine(dunning.Write("Sara", new DateOnly(2026, 9, 20), amount, invoice, failures.Count));


Console.WriteLine("-----------------------------------------------------------");

var pick = new WarehousePickList();
pick.AddNeed("BOLT", "A", 3, 10, 7);
pick.AddNeed("NUT", "B", 1, 5, 5);

var allocations = new StockAllocator().Allocate(pick.Lines);
var path        = new WalkingOrderPlanner().Plan(pick.Lines);

Console.WriteLine(new PickerScriptWriter().Write(path, allocations, pick.Lines));


Console.WriteLine("-----------------------------------------------------------");

var grade = new StudentScores();
TranscriptPlainWriter writer = new TranscriptPlainWriter();
LetterGradeBands bands = new LetterGradeBands();
HonorRollRule honorRollRule = new HonorRollRule(bands);

grade.Record("s1", 92);
grade.Record("s1", 88);
decimal ave = grade.Average("s1");
string letter = bands.Letter(ave);
bool b = honorRollRule.MeetsHonorRoll(ave);
Console.WriteLine(writer.Write("s1", "Ali",ave ,letter,b));

Console.WriteLine("-----------------------------------------------------------");

var hours = new ClinicBusinessHours(
    new TimeOnly(9, 0),
    new TimeOnly(17, 0),
    30);

var book = new AppointmentBook(hours);

var slotFinder = new NextSlotFinder(hours, book);

var slot = slotFinder.FindNextSlot(
    DateTimeOffset.Parse("2026-09-21T08:00:00Z"),
    48);

if (slot is null)
    throw new InvalidOperationException("no slot");

book.TryBook(slot.Value);

var smsReminder = new SmsReminderText();

Console.WriteLine(
    smsReminder.SmsReminder(slot.Value, "0100"));

Console.WriteLine("Done. Now split responsibilities — without breaking behavior.");
