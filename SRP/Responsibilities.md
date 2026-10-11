# SRP Responsibilities

## AppointmentDesk

### Responsibilities

1. **Business hours:** decides when the clinic is open.
2. **Slot search:** finds the next free time.
3. **Bookings:** saves booked times and stops double booking.
4. **ICS file:** builds the calendar file text.
5. **SMS reminder:** writes the reminder message.

### Why this is a problem

Each part has a different reason to change. For example, business-hour rules, booking behavior, calendar format, and SMS wording can change independently.

## CheckoutBasket

### Responsibilities

1. **Basket lines:** adds items and checks the quantity.
2. **Coupon rules:** reads the coupon and calculates the discount.
3. **Gift wrap fee:** adds the gift wrap price.
4. **Total price:** calculates the final price.
5. **Gift card text:** writes the gift card message.
6. **Payment auth code:** creates a fake payment code.

### Why this is a problem

Each part can change for a different reason.

For example, the marketing team can change the coupon or gift card message. The gift wrap price can change. The payment team can change the payment code.

All these changes are inside the same class.

## CourseEnrollmentDesk

### Responsibilities

1. **Seats and waitlist:** keeps who has a seat, who waits, and moves people from the waitlist to a seat.
2. **Welcome packet text:** writes the welcome message in markdown.
3. **Invoice line:** builds the money line with the tax (VAT).

### Why this is a problem

Each part can change for a different reason.

Marketing can change the welcome text. Finance can change the invoice or tax. The school can change the seat rules.

All three are in the same class, so one change can affect another part.

## GradeBook

### Responsibilities

1. **Score storage and average:** keeps the scores and finds the average.
2. **Letter grades:** turns an average into A, B, C, D, or F.
3. **Honor roll rule:** decides if a student is on the honor roll.
4. **Transcript text:** writes the transcript for one student.
5. **CSV export:** writes the grades of all students as CSV.

### Why this is a problem

Each part can change for a different reason.

The school can change the letter grades or honor rule. The registrar can change the transcript layout. Another team can change the CSV format.

All these changes are inside the same class.

## KitchenTicket

### Responsibilities

1. **Ticket items:** keeps the dishes, their ingredients, and prep time.
2. **Allergen check:** looks at ingredients and finds allergens.
3. **Cook time estimate:** estimates when the food will be ready.
4. **Printed ticket layout:** builds the text for the thermal printer.
5. **Expo lane choice:** picks the lane for the order.

### Why this is a problem

Each part can change for a different reason.

The law can change the allergen rules. The kitchen can change the time rules. The printer can change the ticket layout. The restaurant can change the lane rules.

All these changes are inside the same class.

## LoanDesk

### Responsibilities

1. **Application data:** keeps the loan application data.
2. **Risk and eligibility:** calculates the risk score and decides if the loan is eligible.
3. **Required documents:** makes the list of required documents.
4. **Decision letter:** writes the approval or rejection letter.
5. **Underwriter CSV row:** writes one line for the analytics file.

### Why this is a problem

Each part can change for a different reason.

The risk team can change the risk formula. The law can change the document list. The legal team can change the letter text. Analytics can change the CSV format.

All these changes are inside the same class.

## SubscriptionBilling

### Responsibilities

1. **Subscription data:** keeps the customer, monthly price, billing period, and failed payment count.
2. **Proration math:** calculates how much to charge for a partial period.
3. **Invoice numbers:** creates the next invoice number.
4. **Dunning email:** writes the email for late payment.
5. **Ledger line:** writes one line for the accounting export.

### Why this is a problem

Each part can change for a different reason.

Finance can change the proration rules or ledger format. Operations can change the invoice number format. The collections team can change the email text.

All these changes are inside the same class.

## SupportTicket

### Responsibilities

1. **Ticket data:** keeps the ticket information.
2. **Priority from text:** reads the text and chooses P1, P2, or P3.
3. **SLA clock:** finds the deadline and checks if it is late.
4. **Public reply:** writes the reply to the customer.
5. **Escalation note:** writes the internal escalation message.

### Why this is a problem

Each part can change for a different reason.

The support team can change the keywords. The SLA team can change the time rules. The customer team can change the reply text. The support operations team can change the escalation format.

All these changes are inside the same class.

## WarehousePickList

### Responsibilities

1. **Need lines:** keeps what the warehouse must pick.
2. **Stock allocation:** decides how many items we can really give.
3. **Walking order:** decides the order of aisles and bins.
4. **Picker script:** writes the steps for the worker.
5. **WMS XML batch:** writes the XML for the warehouse system.

### Why this is a problem

Each part can change for a different reason.

The warehouse layout can change the walking order. The stock rules can change the allocation. The worker text can change. The WMS XML contract can also change.

All these responsibilities are inside the same class.

## WardBoard

### Responsibilities

1. **Bed assignments:** keeps which patient is in which bed.
2. **Acuity score:** turns heart rate and oxygen into a score.
3. **Pager rules:** decides when to send a pager code and keeps the pager log.
4. **Handoff note:** writes the note for the next nurse.
5. **Census CSV:** writes the list of beds as CSV.

### Why this is a problem

Each part can change for a different reason.

Doctors can change the score rules. The hospital can change the pager rules. Nurses can change the note format. IT can change the CSV format.

All these responsibilities are inside the same class.