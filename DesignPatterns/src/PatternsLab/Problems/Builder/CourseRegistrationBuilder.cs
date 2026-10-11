namespace PatternsLab.Problems.Builder;

public class CourseRegistrationBuilder
{
    // Required
    private string _studentEmail;
    private string _courseCode;
    private string _accessMode;
    // optional
    private string? _groupCode;
    private string? _discountCode;
    private bool _sendWhatsApp;
    private bool _sendEmailWelcome;
    private string? _mentorNote;
    private DateOnly? _preferredStart;

    public CourseRegistrationBuilder(string studentEmail , string courseCode , string accessMode)
    {
        (_studentEmail, _courseCode, _accessMode) = (studentEmail, courseCode, accessMode);
    }
    
    public CourseRegistrationBuilder HasGroupCode(string groupCode)
    {
        _groupCode = groupCode;
        return this;
    }

    public CourseRegistrationBuilder HasDiscountCode(string discountCode)
    {
        _discountCode = discountCode;
        return this;
    }

    public CourseRegistrationBuilder SendWhatsApp(bool sendWhatsApp)
    {
        _sendWhatsApp = sendWhatsApp;
        return this;
    }

    public CourseRegistrationBuilder SendEmailWelcome(bool sendEmailWelcome)
    {
        _sendEmailWelcome = sendEmailWelcome;
        return this;
    }

    public CourseRegistrationBuilder WithMentorNote(string mentorNote)
    {
        _mentorNote = mentorNote;
        return this;
    }

    public CourseRegistrationBuilder WithPreferredStart(DateOnly preferredStart)
    {
        _preferredStart = preferredStart;
        return this;
    }

    public CourseRegistration Build()
    {
        if (string.IsNullOrWhiteSpace(_studentEmail)) throw new ArgumentException("email required");
        if (string.IsNullOrWhiteSpace(_courseCode)) throw new ArgumentException("course required");

        if (_accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");
        if (_accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(_groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        return new CourseRegistration(
            _studentEmail,
            _courseCode,
            _accessMode,
            _groupCode,
            _discountCode,
            _sendWhatsApp,
            _sendEmailWelcome,
            _mentorNote,
            _preferredStart
        );
    }
    
    
}