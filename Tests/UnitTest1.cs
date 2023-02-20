using Program;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddValidContact()
        {
            var contactService = new ContactService();
            bool expected = true;
            int expectedCount = 1;

            bool result = contactService.AddContact("Gabriel", "(11)91234-5678", "test@email.com");

            Assert.Equal(contactService.contacts.Count, expectedCount);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void TestAddInvalidContact()
        {
            var contactService = new ContactService();
            int expectedCount = 1;
            bool expected = true;

            bool result = contactService.AddContact("", "invalid phone", "invalid email");

            Assert.Equal(contactService.contacts.Count, expectedCount);
            Assert.Equal(result, expected);
        }

        [Fact]
        public void TestAddDuplicatedContact()
        {
            var contactService = new ContactService();
            int expectedCount = 2;

            contactService.AddContact("Gabriel", "(11)91234-5678", "test@email.com");
            contactService.AddContact("Gabriel", "(11)91234-5678", "test@email.com");

            Assert.Equal(contactService.contacts.Count, expectedCount);
        }

        [Fact]
        public void TestListContactsWithNoContactsAdded()
        {
            var contactService = new ContactService();
            string expected = "Não há contatos cadastrados.";

            string result = contactService.ListContacts();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestListContactsWithContactsAdded()
        {
            var contactService = new ContactService();
            string name = "Gabriel";
            string phone = "(11)91234-5678";
            string email = "test@email.com";
            string expected = "Lista de contatos:\n";
            expected += $"1. {name} - {phone} - {email}\n";
            contactService.AddContact(name, phone, email);

            string result = contactService.ListContacts();

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestUpdateValidContact()
        {
            var contactService = new ContactService();
            string initialName = "Test";
            string updatedName = "Gabriel";
            string expected = $"Contato '{updatedName}' atualizado com sucesso.";
            string phone = "";
            string email = "";

            contactService.AddContact(initialName, phone, email);
            int contactIndex = contactService.contacts.Count - 1;
            string result = contactService.UpdateContact(contactIndex, updatedName, phone, email);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void TestUpdateInvalidContact()
        {
            var contactService = new ContactService();
            string initialName = "Test";
            string updatedName = "Gabriel";
            string expected = "Índice inválido. Tente novamente.";
            string phone = "";
            string email = "";

            contactService.AddContact(initialName, phone, email);
            int invalidContactIndex = contactService.contacts.Count;
            string result = contactService.UpdateContact(invalidContactIndex, updatedName, phone, email);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void TestRemoveValidContact()
        {
            var contactService = new ContactService();
            string initialName = "Test";
            string expected = $"Contato '{initialName}' removido com sucesso.";
            string phone = "";
            string email = "";

            contactService.AddContact(initialName, phone, email);
            int contactIndex = contactService.contacts.Count - 1;
            string result = contactService.RemoveContact(contactIndex);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void TestRemoveInvalidContact()
        {
            var contactService = new ContactService();
            string initialName = "Test";
            string expected = "Índice inválido. Tente novamente.";
            string phone = "";
            string email = "";

            contactService.AddContact(initialName, phone, email);
            int invalidContactIndex = contactService.contacts.Count;
            string result = contactService.RemoveContact(invalidContactIndex);

            Assert.Equal(result, expected);
        }
    }
}