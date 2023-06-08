class StoreHeader extends HTMLElement {
    connectedCallback() {
        this.innerHTML = 
        `
            <div class="flex-justify-center">
                <div class="navBar input-field">
                    <a class="input-field" href="Home.html")">Home</a>
                    <a class="input-field" href="Guitars.html">Guitars</a>
                    <a class="input-field" href="Drums.html">Drums</a>
                    <a class="input-field" href="Cart.html">Cart</a>
                </div>
            </div>
        `;
    }
}

class StoreCategoryGraphic extends HTMLElement {
    connectedCallback() {
        this.innerHTML = 
        `
            <div class="flex-justify-center">
                <object id="categoryGraphic" data="../res/guitar.svg"></object>
            </div>
        `;
    }
}

customElements.define("store-header", StoreHeader);
customElements.define("store-category-graphic", StoreCategoryGraphic);