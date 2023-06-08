var martinGuitar;
var takamineGuitar;
var guitarList;

function OnGuitarPageLoad() {
    martinGuitar = new Item(
        'Martin Guitars DJr-10E StreetMaster',
        869,
        'https://th.bing.com/th/id/OIP.pmWFAzk1EckQZnOGKoEpxQHaHa?pid=ImgDet&rs=1',
        `
            <li>Style: Dreadnought - D Junior-14 Fret</li>
            <li>Top: Sapele</li>
            <li>Back and sides: Sapele</li>
            <li>X-Brace 1/4" spruce</li>
            <li>Neck: selected hardwood</li>
            <li>Fingerboard: Richlite</li>
            <li>White Style 28 Mother-of-Pearl fingerboard inlays</li>
            <li>Mother-of-Pearl pattern multi-stripe rosette</li>
            <li>Scale: 610 mm (24")</li>
            <li>Fretboard radius: 16"</li>
            <li>Nut width: 44.5 mm (1.75")</li>
            <li>White Corian nut</li>
            <li>Pickup: Fishman Sonitone</li>
            <li>20 Frets</li>
            <li>Richlite bridge with compensated white TUSQ saddle</li>
            <li>String spacing at bridge: 54.8 mm (2.16")</li>
            <li>Enclosed chrome tuners</li>
            <li>Colour: Mahogany Burst</li>
            <li>Incl. gig bag</li>
        `);
    takamineGuitar = new Item(
        'Takamine GD20CE-N',
        399,
        'https://th.bing.com/th/id/R.0b750729f0f0f4beed85d1c601ce9cd8?rik=fptDoP%2fbquh3DA&pid=ImgRaw&r=0',
        `
            <li>Steel String Guitar</li>
            <li>Build: Dreadnought with cutaway</li>
            <li>Top: Solid cedar</li>
            <li>X bracing</li>
            <li>Back and sides: Mahogany</li>
            <li>Neck: Mahogany</li>
            <li>Fretboard and bridge: Ovangkol</li>
            <li>Matte neck finish</li>
            <li>20 Frets</li>
            <li>Scale: 643 mm</li>
            <li>Nut width: 43 mm</li>
            <li>Ex-factory stringing: D'Addario EXP16 .012 - .053</li>
            <li>Pickup: Takamine TP-4TD preamp with built-in tuner</li>
            <li>Colour: Natural matte</li>
        `);
    guitarList = new CategoryItemList("guitarList");
    guitarList.AddItem(martinGuitar);
    guitarList.AddItem(takamineGuitar);
}



class Item {
    Uid;
    Name;
    Price;
    ImageSrc;
    Description;
    CountInCart;
    QuantityToAddToCartInputFieldUid;
    QuantityInCartInputFieldUid;
    AddToCartButtonUid;
    RemoveFromCartButtonUid;
    static TotalItemCount = 0;

    constructor(name, price, imageSrc, description)
    {
        this.Uid = "item_" + Item.TotalItemCount;
        this.Name = name;
        this.Price = price;
        this.ImageSrc = imageSrc;
        this.Description = description;
        this.CountInCart = 0;
        this.QuantityToAddToCartInputFieldUid = this.Uid + "_qtyToAddToCartInputField";
        this.QuantityInCartInputFieldUid = this.Uid + "_qtyInCartInputField";
        this.AddToCartButtonUid = this.Uid + "_addToCartButton";
        this.RemoveFromCartButtonUid = this.Uid + "_removeFromCartButton";
        Item.TotalItemCount++;
    }
}

class ItemSeperatedInputIds {
    Se
    SeperatedButtonUid;
    SeperatedButtonText;
    SeperatedItemQuantityUid;
}

class ItemList {
    Uid;
    ItemTemplateId;
    List;

    constructor(whereToPlace) {
        this.List = new Array();
        this.Uid = whereToPlace;
        this.ItemTemplateId = this.Uid + "_template";
        var htmlComponent =
            `<table class="itemList" id=${this.Uid}>
                <tr>
                    <th></th>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th></th>
                </tr>
                <template class="item" id=${this.ItemTemplateId}>
                </template>
            </table>`;
        document.getElementById(this.Uid).outerHTML = htmlComponent;
    }

    AddItem(item, buttonUid, itemQtyUid, buttonText) {
        let itemSeperated = new ItemWithSeperatedInputIds(item);
        this.List.push(new ItemWithSeperatedInputIds({
            
        }));


        // To be moved to Show() method
        let templateElement = document.getElementById(this.ItemTemplateId);
        let trElement = document.createElement("tr");
        let index;

        // Copy the children
        while (templateElement.firstChild) {
            trElement.appendChild(templateElement.firstChild); // *Moves* the child
        }

        // Copy the attributes
        for (index = templateElement.attributes.length - 1; index >= 0; --index) {
            trElement.attributes.setNamedItem(templateElement.attributes[index].cloneNode());
        }

        templateElement.parentNode.replaceChild(trElement, templateElement);

        trElement.after(templateElement);
        trElement.setAttribute("id", item.Uid);
        trElement.innerHTML =
            `<td>
                <img src=${item.ImageSrc}/>
            </td>
            <td>${item.Name}</td>
            <td>${item.Price} €</td>
            <td>
                <input id=${itemQtyUid} class="input-field" type="number" min="1">
            </td>
            <td class="add-to-cart-column">
                <button
                    id=${buttonUid}
                    class="input-field">
                        ${buttonText}
                </button>
            </td>`;
        this.List.push(item);
    }
}


class CategoryItemList extends ItemList {
    static CartItemList;
    static IsAnyCategoryItemListCreated = false;

    constructor(whereToPlace) {
        super(whereToPlace);
        if (!IsAnyCategoryItemListCreated) {
            CategoryItemList.CartItemList = new CartItemList()
        }
    }

    AddItem(item) {
        let btnText = "Add to cart";
        super.AddItem(item, item.AddToCartButtonUid, item.QuantityToAddToCartInputFieldUid, btnText);
        document.getElementById(item.AddToCartButtonUid).addEventListener('click', this.OnAddToCart);
    }

    OnAddToCart() {
        //add item to cart
        
    }
}


class CartItemList extends ItemList {
    TotalPrice;

    constructor(whereToPlace) {
        super(whereToPlace);
    }

    AddItem(item) {
        let btnText = "Remove from cart";
        var itemAlreadyInList = false;
        this.List.forEach(itemInList => {
            if (itemInList.CategoryItemUid == item.CategoryItemUid) {
                itemInList.Count++;
                document.getElementById(item.QuantityInputFieldUid).setAttribute("value", itemInList.Count);
                itemAlreadyInList = true;
            }
        });
        if (!itemAlreadyInList) {
            super.AddItem(item, item.RemoveFromCartButtonUid, btnText);
            document.getElementById(item.RemoveFromCartButtonUid).addEventListener('click', this.OnRemoveFromCart());
            document.getElementById(item.QuantityInputFieldUid).addEventListener('change', this.OnQuantityChange());
        }
    }

    OnRemoveFromCart() {
        //remove item from cart
    }

    OnQuantityChange() {
        //update total price
    }
}