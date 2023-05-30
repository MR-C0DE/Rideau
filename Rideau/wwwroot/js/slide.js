let annimation = () => {
    const photo = ['book', 'book2'];
    let index = 0;
    let changement = () => {
        if (index >= photo.length) {
            index = 0;
        }
        let img = $('.image-slide');
        let file = photo[index] + '.jpg';
        let path = './img/' + file;

        img.attr('src', path);
        index++;

    };

    setInterval(changement, 8000);
}
annimation();