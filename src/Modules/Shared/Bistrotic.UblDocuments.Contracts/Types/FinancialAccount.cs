namespace Bistrotic.UblDocuments.Types
{
    public class FinancialAccount
    {
        /// <summary>
        /// A class to describe a financial account.
        /// <para/>
        /// ComponentType: ABIE
        /// <para/>
        /// DictionaryEntryName: Financial Account. Details
        /// <para/>
        /// ObjectClass: Financial Account
        /// </summary>
#if FEATURE_SERIALIZATION
    [System.SerializableAttribute()]
#endif

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute("FinancialAccount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
        [System.Xml.Serialization.XmlRootAttribute("FinancialAccount", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2", IsNullable = false)]
        public partial class FinancialAccountType
        {
            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            [System.Xml.Serialization.XmlElementAttribute("AccountFormatCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 4)]
            public CodeType @__AccountFormatCode;

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            [System.Xml.Serialization.XmlElementAttribute("AccountTypeCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 3)]
            public CodeType @__AccountTypeCode;

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            [System.Xml.Serialization.XmlElementAttribute("AliasName", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 2)]
            public NameType @__AliasName;

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            [System.Xml.Serialization.XmlElementAttribute("Country", Order = 8)]
            public CountryType @__Country;

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            [System.Xml.Serialization.XmlElementAttribute("CurrencyCode", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 5)]
            public CodeType @__CurrencyCode;

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            [System.Xml.Serialization.XmlElementAttribute("FinancialInstitutionBranch", Order = 7)]
            public BranchType @__FinancialInstitutionBranch;

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            [System.Xml.Serialization.XmlElementAttribute("ID", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 0)]
            public IdentifierType @__ID;

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            [System.Xml.Serialization.XmlElementAttribute("Name", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 1)]
            public NameType @__Name;

            private System.Collections.Generic.List<TextType> _paymentNote;

            [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
            [System.Xml.Serialization.XmlElementAttribute("PaymentNote", Namespace = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2", Order = 6)]
            public TextType[] @__PaymentNote
            {
                get
                {
                    return _paymentNote?.ToArray();
                }
                set
                {
                    _paymentNote = value == null ? null : new System.Collections.Generic.List<TextType>(value);
                }
            }

            /// <summary>
            /// A code signifying the format of this financial account.
            /// <para/>
            /// ComponentType: BBIE
            /// <para/>
            /// DictionaryEntryName: Financial Account. Account Format Code. Code
            /// <para/>
            /// Cardinality: 0..1
            /// <para/>
            /// ObjectClass: Financial Account
            /// <para/>
            /// PropertyTerm: Account Format Code
            /// <para/>
            /// RepresentationTerm: Code
            /// <para/>
            /// DataType: Code. Type
            /// </summary>
            /// <example>ISO20022 Clearing System Identification Code</example>
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public CodeType AccountFormatCode
            {
                get
                {
                    if (__AccountFormatCode == null) { __AccountFormatCode = new CodeType(); }
                    return __AccountFormatCode;
                }
                set
                {
                    __AccountFormatCode = value;
                }
            }

            /// <summary>
            /// A code signifying the type of this financial account.
            /// <para/>
            /// ComponentType: BBIE
            /// <para/>
            /// DictionaryEntryName: Financial Account. Account Type Code. Code
            /// <para/>
            /// Cardinality: 0..1
            /// <para/>
            /// ObjectClass: Financial Account
            /// <para/>
            /// PropertyTerm: Account Type Code
            /// <para/>
            /// RepresentationTerm: Code
            /// <para/>
            /// DataType: Code. Type
            /// </summary>
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public CodeType AccountTypeCode
            {
                get
                {
                    if (__AccountTypeCode == null) { __AccountTypeCode = new CodeType(); }
                    return __AccountTypeCode;
                }
                set
                {
                    __AccountTypeCode = value;
                }
            }

            /// <summary>
            /// An alias for the name of this financial account, to be used in place of the actual
            /// account name for security reasons.
            /// <para/>
            /// ComponentType: BBIE
            /// <para/>
            /// DictionaryEntryName: Financial Account. Alias_ Name. Name
            /// <para/>
            /// Cardinality: 0..1
            /// <para/>
            /// ObjectClass: Financial Account
            /// <para/>
            /// PropertyTermQualifier: Alias
            /// <para/>
            /// PropertyTerm: Name
            /// <para/>
            /// RepresentationTerm: Name
            /// <para/>
            /// DataType: Name. Type
            /// </summary>
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public NameType AliasName
            {
                get
                {
                    if (__AliasName == null) { __AliasName = new NameType(); }
                    return __AliasName;
                }
                set
                {
                    __AliasName = value;
                }
            }

            /// <summary>
            /// The country in which the holder of the financial account is domiciled.
            /// <para/>
            /// ComponentType: ASBIE
            /// <para/>
            /// DictionaryEntryName: Financial Account. Country
            /// <para/>
            /// Cardinality: 0..1
            /// <para/>
            /// ObjectClass: Financial Account
            /// <para/>
            /// PropertyTerm: Country
            /// <para/>
            /// AssociatedObjectClass: Country
            /// <para/>
            /// RepresentationTerm: Country
            /// </summary>
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public CountryType Country
            {
                get
                {
                    if (__Country == null) { __Country = new CountryType(); }
                    return __Country;
                }
                set
                {
                    __Country = value;
                }
            }

            /// <summary>
            /// A code signifying the currency in which this financial account is held.
            /// <para/>
            /// ComponentType: BBIE
            /// <para/>
            /// DictionaryEntryName: Financial Account. Currency Code. Code
            /// <para/>
            /// Cardinality: 0..1
            /// <para/>
            /// ObjectClass: Financial Account
            /// <para/>
            /// PropertyTerm: Currency Code
            /// <para/>
            /// RepresentationTerm: Code
            /// <para/>
            /// DataTypeQualifier: Currency
            /// <para/>
            /// DataType: Currency_ Code. Type
            /// </summary>
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public CodeType CurrencyCode
            {
                get
                {
                    if (__CurrencyCode == null) { __CurrencyCode = new CodeType(); }
                    return __CurrencyCode;
                }
                set
                {
                    __CurrencyCode = value;
                }
            }

            /// <summary>
            /// The branch of the financial institution associated with this financial account.
            /// <para/>
            /// ComponentType: ASBIE
            /// <para/>
            /// DictionaryEntryName: Financial Account. Financial Institution_ Branch. Branch
            /// <para/>
            /// Cardinality: 0..1
            /// <para/>
            /// ObjectClass: Financial Account
            /// <para/>
            /// PropertyTermQualifier: Financial Institution
            /// <para/>
            /// PropertyTerm: Branch
            /// <para/>
            /// AssociatedObjectClass: Branch
            /// <para/>
            /// RepresentationTerm: Branch
            /// </summary>
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public BranchType FinancialInstitutionBranch
            {
                get
                {
                    if (__FinancialInstitutionBranch == null) { __FinancialInstitutionBranch = new BranchType(); }
                    return __FinancialInstitutionBranch;
                }
                set
                {
                    __FinancialInstitutionBranch = value;
                }
            }

            /// <summary>
            /// The identifier for this financial account; the bank account number.
            /// <para/>
            /// ComponentType: BBIE
            /// <para/>
            /// DictionaryEntryName: Financial Account. Identifier
            /// <para/>
            /// Cardinality: 0..1
            /// <para/>
            /// ObjectClass: Financial Account
            /// <para/>
            /// PropertyTerm: Identifier
            /// <para/>
            /// RepresentationTerm: Identifier
            /// <para/>
            /// DataType: Identifier. Type
            /// </summary>
            /// <example>SWIFT(BIC) and IBAN are defined in ISO 9362 and ISO 13616.</example>
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public IdentifierType ID
            {
                get
                {
                    if (__ID == null) { __ID = new IdentifierType(); }
                    return __ID;
                }
                set
                {
                    __ID = value;
                }
            }

            /// <summary>
            /// The name of this financial account.
            /// <para/>
            /// ComponentType: BBIE
            /// <para/>
            /// DictionaryEntryName: Financial Account. Name
            /// <para/>
            /// Cardinality: 0..1
            /// <para/>
            /// ObjectClass: Financial Account
            /// <para/>
            /// PropertyTerm: Name
            /// <para/>
            /// RepresentationTerm: Name
            /// <para/>
            /// DataType: Name. Type
            /// </summary>
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public NameType Name
            {
                get
                {
                    if (__Name == null) { __Name = new NameType(); }
                    return __Name;
                }
                set
                {
                    __Name = value;
                }
            }

            /// <summary>
            /// Free-form text applying to the Payment for the owner of this account.
            /// <para/>
            /// ComponentType: BBIE
            /// <para/>
            /// DictionaryEntryName: Financial Account. Payment_ Note. Text
            /// <para/>
            /// Cardinality: 0..n
            /// <para/>
            /// ObjectClass: Financial Account
            /// <para/>
            /// PropertyTermQualifier: Payment
            /// <para/>
            /// PropertyTerm: Note
            /// <para/>
            /// RepresentationTerm: Text
            /// <para/>
            /// DataType: Text. Type
            /// </summary>
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public System.Collections.Generic.List<TextType> PaymentNote
            {
                get { return _paymentNote ?? (_paymentNote = new System.Collections.Generic.List<TextType>()); }
                set { _paymentNote = value; }
            }
        }
    }
}