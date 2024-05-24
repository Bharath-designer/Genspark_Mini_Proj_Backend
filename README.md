# Event Management App

## Entities

**Users**

- UserId (PK)
- HashedPassword
- PasswordHashKey
- Role (Client, Admin)
- CreatedDate

**UserProfiles**

- UserProfileId (PK)
- UserId (FK)
- Email
- FullName
- PhoneNumber

**EventCategories**

- EventId (PK)
- EventName
- Description
- CreatedDate

**QuotationRequests**

- QuotationRequestId (PK)
- UserId (FK)
- EventId (FK)
- ExpectedPeopleCount
- EventVenueType (OwnVenue, PrivateVenue)
- VenueDetails
- EventType
- FoodPreference
- CateringDetails
- SpecialInstructions
- EventDate
- EventDuration
- RequestStatus (Pending, Accepted, Rejected) (By Admin)
- RequestedDate

**QuotationResponses**

- QuotationResponseId (PK)
- QuotationRequestId (FK)
- QuotedAmount (By the admin)
- ResponseMessage
- ResponseStatus (Pending, Accepted, Rejected) (By Client)
- ResponseDate

**Payments**

- PaymentId (PK)
- QuotationResponseId (FK)
- Amount
- PaymentDate
- PaymentStatus (Pending, Completed, Failed)
- PaymentMethod (CreditCard, PayPal, etc.)


**Notifications**

- NotificationId (PK)
- UserId (FK)
- Message
- NotificationDate
- IsRead

**Reviews**

- ReviewId (PK)
- QuotationResponseId (FK)
- EventId (FK)
- UserId (FK)
- Rating
- Comments
- ReviewDate
