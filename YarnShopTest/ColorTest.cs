using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YarnShop.Core.Domain;
using YarnShop.Core.Repositories;
using YarnShop.Infrastructure.DTO;
using YarnShop.Infrastructure.Services;

namespace YarnShopTest
{
    [TestClass]
    public class ColorTest : TestBase
    {
        [TestMethod]
        public async Task addColor_should_throw_NullReferenceException_when_addedColorIsNull()
        {
            Color color = null;
            Func<Task> addNullColorAction = () => _colorsService.AddColor(color);
            await Assert.ThrowsExceptionAsync<NullReferenceException>(addNullColorAction);
        }

        [TestMethod]
        public async Task browseAll_should_returnEmptyList_when_repositoryIsEmpty()
        {
            var emptyRepository = new List<Color>();
            _mockedColorsRepository.Setup(c => c.GetAllAsync()).ReturnsAsync(emptyRepository);

            var browsed = await _colorsService.BrowseAll();
            var browsedList = browsed.ToList();

            var expectedBrowsedList = new List<ColorDTO>();
            Assert.IsTrue(expectedBrowsedList.SequenceEqual(browsedList));
        }

        [TestMethod]
        public async Task browseAll_should_returnList_when_repositoryIsNotEmpty()
        {
            var repository = new List<Color>();
            repository.Add(ColorBase());
            _mockedColorsRepository.Setup(c => c.GetAllAsync()).ReturnsAsync(repository);

            var browsed = await _colorsService.BrowseAll();
            var browsedList = browsed.ToList();

            var expectedBrowsedList = new List<ColorDTO>();
            expectedBrowsedList.Add(ColorDtoBase());
            Assert.IsTrue(expectedBrowsedList.SequenceEqual(browsedList));
        }

        [TestMethod]
        public async Task deleteColor_should_throwInvalidOperationException_when_givenIdIsNotInRepository()
        {
            int id = 5;
            _mockedColorsRepository.Setup(c => c.DeleteAsync(id)).ThrowsAsync(new InvalidOperationException());

            Func<Task> deleteColorAction = () => _colorsService.DeleteColor(id);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(deleteColorAction);
        }

        [TestMethod]
        public async Task deleteColor_should_deleteColorFromRepository_when_givenCorrectData()
        {
            int id = 1;
            _mockedColorsRepository.Setup(c => c.DeleteAsync(id));

            await _colorsService.DeleteColor(id);

            _mockedColorsRepository.Verify(skiJumpers => skiJumpers.DeleteAsync(id), Times.Once);
        }

        [TestMethod]
        public async Task editColor_should_throw_NullReferenceException_when_updatedColorIsNull()
        {
            Color color = null;
            int id = 1;

            Func<Task> updateNullColorAction = () => _colorsService.EditColor(color, id);

            await Assert.ThrowsExceptionAsync<NullReferenceException>(updateNullColorAction);
        }

        [TestMethod]
        public async Task editColor_should_throwInvalidOperationException_when_givenIdIsNotInRepository()
        {
            int id = 1;
            Color editedColor = ColorBase();
            editedColor.Name = "xxx";
            Color originalColor = new Color()
            {
                Id = id,
                Name = editedColor.Name,
                n = editedColor.n
            };
            _mockedColorsRepository.Setup(c => c.UpdateAsync(originalColor)).ThrowsAsync(new InvalidOperationException());

            Func<Task> editAction = () => _colorsService.EditColor(editedColor, id);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(editAction);
        }

        [TestMethod]
        public async Task editColor_should_editColorInRepository_when_givenCorrectData()
        {
            int id = 1;
            Color editedColor = ColorBase();
            editedColor.Name = "xxx";
            Color originalColor = new Color()
            {
                Id = id,
                Name = editedColor.Name,
                n = editedColor.n
            };
            _mockedColorsRepository.Setup(c => c.UpdateAsync(originalColor));

            await _colorsService.EditColor(editedColor, id);

            _mockedColorsRepository.Verify(c => c.UpdateAsync(originalColor), Times.Once);
        }

        [TestMethod]
        public async Task getById_should_throwInvalidOperationException_when_givenIdIsNotInRepository()
        {
            int id = 5;
            _mockedColorsRepository.Setup(c => c.GetAsync(id)).ThrowsAsync(new InvalidOperationException());

            Func<Task> getByIdAction = () => _colorsService.GetById(id);

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(getByIdAction);
        }

        [TestMethod]
        public void getById_should_returnColorWithGivenId_when_givenIdIsInRepository()
        {
            Color addedColor = ColorBase();
            int id = addedColor.Id;
            _mockedColorsRepository.Setup(c => c.GetAsync(id)).ReturnsAsync(addedColor);

            var returnedColor = _colorsService.GetById(id);

            ColorDTO expectedColor = ColorDtoBase();
            _mockedColorsRepository.Verify(skiJumper => skiJumper.GetAsync(id), Times.Once());
        }
    }
}
