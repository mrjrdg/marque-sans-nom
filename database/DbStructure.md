# Database Structure

## Model

### Event

- (PK INT) EventId
- (FK INT) OwnerId
- (FK INT) EnterPriseId
- (FK INT) AdresseId
- (FK INT) EventTypeId
- (STRING) Title
- (DOUBLE) PriceToPayToParticipate
- (INT) NumberOfMembers
- (DATETIME) Date
- (DOUBLE) RentalHours

### EventMembers

- (PK INT) UserId 
- (PK INT) EventId

### Entreprise

- (PK INT) EnterpriseId
- (STRING) EnterPriseAdresseHQ
- (STRING) Name
- (STRING) Telephone

### AddresseEnterPriseEventType 

- (PK INT) ID
- (FK INT) AdresseId
- (FK INT) EnterpriseId
- (FK INT) EventTypeId

### EventBundle

- (PK INT) Id 
- (FK INT) AddresseEnterPriseEventTypeID
- (DOUBLE) PricePerHour
- (DOUBLE) MinimumRentalHour

### EventBundleOptions

- (PK INT) Id
- (FK INT) EventBundleId
- (STRING) Name
- (DOUBLE) Price

### Addresse

- (PK INT) AdresseID
- (STRING) Adresse

### EventType

- (PK INT) EventTypeId
- (STRING) Title


